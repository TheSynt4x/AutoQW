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
    class MoveToArea : IJsonPacketHandler
    {
        public string[] HandledCommands { get; } = { "moveToArea" };

        public void Handle(JsonPacket message)
        {
            Player.Client.Write($"%xt%zm%moveToCell%{Player.UserId}%Enter%Spawn%");
            Player.Client.Write($"%xt%zm%retrieveUserDatas%{World.RoomId}%{Player.UserId}%");

            Thread.Sleep(2000);
        }
    }
}
