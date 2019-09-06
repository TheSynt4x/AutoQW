using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Network.Packets
{
    public class Packet
    {
        public string RawContent { get; set; }

        public string Command { get; set; }
             
        public bool Send { get; set; } = true;
    }
}
