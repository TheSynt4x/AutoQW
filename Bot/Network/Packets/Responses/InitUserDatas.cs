using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Networking;
using Bot.Game;
using System.Threading;

namespace Bot.Network.Packets.Responses
{
    class InitUserDatas : IJsonPacketHandler
    {
        public string[] HandledCommands { get; } = { "initUserDatas" };

        public void Handle(JsonPacket message)
        {
            Player.Client.Write($"%xt%zm%retrieveInventory%{World.RoomId}%{Player.UserId}%");

            Thread.Sleep(3000);
        }
    }
}
