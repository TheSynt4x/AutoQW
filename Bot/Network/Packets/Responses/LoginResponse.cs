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
    class LoginResponse : IXtPacketHandler
    {
        public string[] HandledCommands { get; } = { "loginResponse" };

        public void Handle(XtPacket message)
        {
            Player.UserId = int.Parse(message.RawContent.Split('%')[5]);

            Player.Client.Write("%xt%zm%firstJoin%1%");
            Player.Client.Write("%xt%zm%cmd%1%ignoreList%$clearAll%");

            Thread.Sleep(2000);

        }
    }
}
