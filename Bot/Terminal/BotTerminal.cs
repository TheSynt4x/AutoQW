using Bot.Managers.Commands;
using Bot.Managers.Plugins;
using Bot.Terminal.Commands;
using Bot.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Bot.Terminal
{
    public class BotTerminal
    {
        public static BotTerminal Instance { get; set; } = new BotTerminal();

        public List<ICommandHandle> commands = new List<ICommandHandle>()
        {
            new Plugin(),
            new Login()
        };

        public void RegisterCommand(ICommandHandle command) => RegisterCommand(command, commands);
        public void UnregisterCommand(ICommandHandle command) => commands.Remove(command);

        private void RegisterCommand<T>(T type, List<T> list)
        {
            list.Add(type);
        }

        public void Initialize()
        {
            string input = "";

            while (input != "quit") {
                var temp = new List<ICommandHandle>(commands);

                input = InputHandler.GetInput<string>("Command: ");

                var cmd = input.Split(' ');

                foreach (var command in temp.Where(c => c.HandledCommand.Equals(cmd[0], StringComparison.OrdinalIgnoreCase))) 
                {
                    command.Handle(cmd);
                }
            }
        }
    }
}