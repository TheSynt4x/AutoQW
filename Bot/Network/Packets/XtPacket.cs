using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Network.Packets
{
    public class XtPacket : Packet
    {
        public string[] Arguments { get; set; }

        public XtPacket(string raw)
        {
            if (raw != null) {
                RawContent = raw;

                if ((Arguments = raw.Split('%')).Length >= 4) {
                    Command = Arguments[2] == "zm"
                        ? (Arguments[3] == "cmd" ? Arguments[5] : Arguments[3])
                        : Arguments[2];
                }
            }
        }

        public override string ToString()
        {
            return string.Join("%", Arguments);
        }
    }
}
