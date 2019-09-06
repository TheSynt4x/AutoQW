using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Network.Packets
{
    public class JsonPacket : Packet
    {
        public JToken Object { get; }

        public JToken DataObject => Object?["b"]?["o"];

        public JsonPacket(string raw)
        {
            try {
                RawContent = raw;
                Object = JObject.Parse(raw);
                Command = DataObject?["cmd"]?.Value<string>();
            } catch (JsonReaderException) {

            }
        }

        public override string ToString()
        {
            return Object.ToString(Formatting.None);
        }
    }
}
