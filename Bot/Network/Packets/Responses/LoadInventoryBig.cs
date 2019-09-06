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
    class LoadInventoryBig : IJsonPacketHandler
    {
        public string[] HandledCommands { get; } = { "loadInventoryBig" };

        public void Handle(JsonPacket message)
        {
            Player.IsLoggedIn = true;

            Console.WriteLine($"{Player.Client.Username} was connected!");
            Thread.Sleep(3000);

            Player.Client.Write($"%xt%zm%cmd%1%goto%minae%");
        }
    }
}
