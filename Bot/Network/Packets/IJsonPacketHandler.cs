using Bot.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Network.Packets
{
    public interface IJsonPacketHandler
    {
        string[] HandledCommands { get; }
        void Handle(JsonPacket message);
    }
}
