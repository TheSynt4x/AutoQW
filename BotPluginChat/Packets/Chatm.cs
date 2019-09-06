using Bot.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Networking;
using Bot.Game;
using Bot.Terminal;

namespace BotPluginChat.Packets
{
    class Chatm : IXtPacketHandler
    {
        public string[] HandledCommands { get; } = { "chatm" };

        public Action<string, string> OnMessage;

        public void Handle(XtPacket message)
        {
            string msg = message.Arguments[4].Split('~')[1];

            if (Player.CopyTarget != string.Empty && Player.CopyTarget == message.Arguments[5])
                Player.Client.Write($"%xt%zm%message%{World.RoomId}%{msg}%zone%");

            if (msg.StartsWith("!") && message.Arguments[5] == "minae") {
                foreach (var cmd in BotTerminal.Instance.commands) {
                    cmd.Handle(msg.Split(' '));
                }
            }

            if (message.Arguments[4].Split('~')[0] == "zone") {
                OnMessage?.Invoke(message.Arguments[5], msg);
            }
        }
    }
}
