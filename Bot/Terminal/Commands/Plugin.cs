using Bot.Managers.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Managers.Commands
{
    public class Plugin : ICommandHandle
    {
        public string HandledCommand { get; } = "!plugin";

        public void Handle(string[] cmd)
        {
            var type = cmd[1];
            var path = cmd[2];

            switch(type) {
                case "load":
                    BotPlugin p = new BotPlugin(path);

                    if (p.Load()) {
                        Console.WriteLine($"{p.Name} was loaded.");
                        Console.WriteLine(p.Description);
                    } else Console.WriteLine(p.LastError);
                    break;
                case "unload":
                    BotPlugin pn = BotPlugin.Plugins.FirstOrDefault(x => x.Path == path);

                    if (pn.Unload()) {
                        Console.WriteLine($"{pn.Name} was unloaded.");
                    } else Console.WriteLine(pn.LastError);
                    break;
            }
        }
    }
}
