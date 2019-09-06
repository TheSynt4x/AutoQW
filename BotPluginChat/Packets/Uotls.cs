using Bot.Game;
using Bot.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPluginChat.Packets
{
    class Uotls : IXtPacketHandler
    {
        public string[] HandledCommands { get; } = { "uotls" };

        public void Handle(XtPacket message)
        {
            if (Player.FollowTarget != string.Empty && Player.FollowTarget.Equals(message.Arguments[4])) {
                string[] positions = message.Arguments[5].Split(',');

                if (positions[0].Contains("strPad"))
                    Player.Client.Write($"%xt%zm%moveToCell%{World.RoomId}%{positions[2].Split(':')[1]}%{positions[0].Split(':')[1]}%");
                else
                    Player.Client.Write($"%xt%zm%mv%{World.RoomId}%{positions[1].Split(':')[1]}%{positions[2].Split(':')[1]}%{positions[0].Split(':')[1]}%");
            }
        }
    }
}
