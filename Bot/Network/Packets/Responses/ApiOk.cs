using Bot.Game;
using Bot.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bot.Network.Packets.Responses
{
    class ApiOk : IXmlPacketHandler
    {
        public string[] HandledCommands { get; } = { "apiOK" };

        public void Handle(XmlPacket message)
        {
            Player.Client.Write($"<msg t='sys'><body action='login' r='0'><login z='zone_master'><nick><![CDATA[N7B5W8W1Y5B1R5VWVZ~{Player.Client.Username}]]></nick><pword><![CDATA[{Player.Client.Token}]]></pword></login></body></msg>");
            Thread.Sleep(2000);
        }
    }
}
