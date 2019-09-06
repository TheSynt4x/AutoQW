using Bot.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Network.Packets
{
    public interface IXtPacketHandler
    {
        string[] HandledCommands { get; }
        void Handle(XtPacket message);
    }
}
