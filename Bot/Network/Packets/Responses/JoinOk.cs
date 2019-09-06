using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Networking;
using Bot.Game;

namespace Bot.Network.Packets.Responses
{
    class JoinOk : IXmlPacketHandler
    {
        public string[] HandledCommands => throw new NotImplementedException();

        public void Handle(XmlPacket message)
        {
            World.RoomId = int.Parse(message.RawContent.Split('\'')[5]);
        }
    }
}
