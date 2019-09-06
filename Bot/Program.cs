using Bot.Config;
using Bot.Http;
using Bot.Networking;
using Bot.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Terminal;
using System.IO;
using Newtonsoft.Json.Linq;
using Bot.Managers.Plugins;

namespace Bot
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string plugin in JObject.Parse(File.ReadAllText("plugins.json"))["plugins"]) {
                var p = new BotPlugin(plugin);

                if (p.Load()) {
                    Console.WriteLine($"{p.Name} was loaded!");
                    Console.WriteLine(p.Description);
                } else Console.WriteLine(p.LastError);
            }

            BotTerminal.Instance.Initialize();
        }
    }
}
