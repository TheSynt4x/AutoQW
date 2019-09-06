using Bot.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Networking
{
    public abstract class AqwSocket
    {
        protected abstract void OnConnected();

        protected abstract void OnMessageReceived(Packet msg);

        protected abstract void OnMessageSent(Packet msg);

        protected abstract void OnDisconnected();

        private const int BufferSize = 1024;

        private readonly byte[] _readBuffer = new byte[BufferSize];

        private List<byte> _spillBuffer = new List<byte>();

        private readonly TcpClient _client = new TcpClient();

        private bool _connected;

        public void Close()
        {
            _connected = false;
            _client.Close();
            OnDisconnected();
        }

        public void Connect(IPAddress addr, ushort port)
        {
            if (!_connected) {
                try {
                    _client.BeginConnect(addr, port, OnConnect, null);
                } catch {
                    Close();
                }
            }
        }

        private void Read()
        {
            if (_connected) {
                try {
                    _client.GetStream().BeginRead(_readBuffer, 0, BufferSize, OnRead, null);
                } catch {
                    Close();
                }
            }
        }

        public void Write(string message)
        {
            if (_connected) {
                byte[] msg = Encoding.UTF8.GetBytes(message + "\0");

                try {
                    _client.GetStream().BeginWrite(msg, 0, msg.Length, OnWrite, message);
                } catch {
                    Close();
                }
            }
        }

        private void OnConnect(IAsyncResult result)
        {
            try {
                _client.EndConnect(result);
                _connected = true;
                OnConnected();
                Read();
            } catch {
                Close();
                return;
            }
        }

        private void OnWrite(IAsyncResult result)
        {
            if (_connected) {
                try {
                    _client.GetStream().EndWrite(result);

                    Packet packet = CreatePacket((string)result.AsyncState);

                    OnMessageSent(packet);
                } catch {
                    Close();
                }
            }
        }

        private void OnRead(IAsyncResult result)
        {
            if (!_connected)
                return;

            int read;

            try {
                read = _client.GetStream().EndRead(result);
                if (read <= 0)
                    throw new SocketException();
            } catch {
                Close();
                return;
            }

            int i = 0;

            while (--read >= 0) {
                byte b = _readBuffer[i++];

                if (b != 0) {
                    _spillBuffer.Add(b);
                } else {
                    Packet packet = CreatePacket(Encoding.UTF8.GetString(_spillBuffer.ToArray()));

                    OnMessageReceived(packet);
                    _spillBuffer = new List<byte>();
                }
            }

            if (_connected)
                Read();
        }

        private Packet CreatePacket(string raw)
        {
            if (raw?.Length > 0) {
                switch (raw[0]) {
                    case '<': return new XmlPacket(raw);
                    case '%': return new XtPacket(raw);
                    case '{': return new JsonPacket(raw);
                }
            }

            return null;
        }
    }
}
