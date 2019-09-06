using Bot.Network.Packets;
using Bot.Network.Packets.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Networking
{
    public class Client : AqwSocket
    {
        public event Action Disconnected;

        public readonly string Username;

        public readonly string Token;

        private bool _shutdown;

        private List<IJsonPacketHandler> _packetsJson = new List<IJsonPacketHandler>()
        {
            new MoveToArea(),
            new InitUserDatas(),
            new LoadInventoryBig()
        };

        private List<IXmlPacketHandler> _packetsXml = new List<IXmlPacketHandler>()
        {
            new ApiOk(),
            new JoinOk()
        };

        private List<IXtPacketHandler> _packetsXt = new List<IXtPacketHandler>()
        {
            new LoginResponse(),
        };

        public Client(string user, string token)
        {
            Username = user;
            Token = token;
        }

        public void RegisterHandler(IJsonPacketHandler handler) => RegisterHandler(handler, _packetsJson);
        public void RegisterHandler(IXmlPacketHandler handler) => RegisterHandler(handler, _packetsXml);
        public void RegisterHandler(IXtPacketHandler handler) => RegisterHandler(handler, _packetsXt);
        public void UnregisterHandler(IJsonPacketHandler handler) => _packetsJson.Remove(handler);
        public void UnregisterHandler(IXmlPacketHandler handler) => _packetsXml.Remove(handler);
        public void UnregisterHandler(IXtPacketHandler handler) => _packetsXt.Remove(handler);

        private void RegisterHandler<T>(T handler, List<T> list)
        {
            if (!list.Contains(handler))
                list.Add(handler);
        }

        protected override void OnConnected()
        {
            Write("<msg t='sys'><body action='verChk' r='0'><ver v='157' /></body></msg>");
        }

        protected override void OnDisconnected()
        {
            _shutdown = true;
            Disconnected?.Invoke();
        }

        private void ProcessMessage(Packet message)
        {
            try {
                var tempJson = new List<IJsonPacketHandler>(_packetsJson);
                var tempXml = new List<IXmlPacketHandler>(_packetsXml);
                var tempXt = new List<IXtPacketHandler>(_packetsXt);

                switch (message) {
                    case JsonPacket json:
                        foreach (IJsonPacketHandler handler in tempJson.Where(h => h.HandledCommands.Contains(json.Command)))
                            handler.Handle(json);
                        break;
                    case XmlPacket xml:
                        foreach (IXmlPacketHandler handler in tempXml.Where(h => h.HandledCommands.Contains(xml.Command)))
                            handler.Handle(xml);
                        break;
                    case XtPacket xt:
                        foreach (IXtPacketHandler handler in tempXt.Where(h => h.HandledCommands.Contains(xt.Command)))
                            handler.Handle(xt);
                        break;
                }
            } catch(Exception ex) {
                
            }
        }

        protected override void OnMessageReceived(Packet msg)
        {
            if (_shutdown)
                return;

            Console.WriteLine($"Received: {msg.RawContent}");

            ProcessMessage(msg);
        }

        protected override void OnMessageSent(Packet msg)
        {
            if (_shutdown)
                return;

            Console.WriteLine($"Sent: {msg.RawContent}");

            ProcessMessage(msg);
        }
    }
}
