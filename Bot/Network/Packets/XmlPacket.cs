using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bot.Network.Packets
{
    public class XmlPacket : Packet
    {
        public XmlDocument Body { get; }

        public XmlPacket(string raw)
        {
            try {
                RawContent = raw;
                Body = new XmlDocument();
                Body.LoadXml(raw);
                Command = raw.Contains("cross-domain-policy")
                    ? "policy"
                    : Body.DocumentElement?["body"]?.Attributes["action"]?.Value;
            } catch (XmlException) {

            }
        }

        public override string ToString()
        {
            return Body.OuterXml;
        }
    }
}
