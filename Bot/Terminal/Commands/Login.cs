using Bot.Config;
using Bot.Game;
using Bot.Http;
using Bot.Managers.Commands;
using Bot.Networking;
using Bot.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Terminal.Commands
{
    class Login : ICommandHandle
    {
        public string HandledCommand { get; } = "!login";

        public async void Handle(string[] cmd)
        {
            if (!Player.IsLoggedIn) {
                var username = cmd[1];
                var password = cmd[2];

                string token = await LoginRequest.GetUserToken(username, password);

                Player.Client = new Client(username, token);
                Player.Client.Disconnected += client_Disconnected;

                Player.Client.Connect(Settings.Address, Settings.Port);
            }
        }

        private void client_Disconnected()
        {
            Console.WriteLine("Client was disconnected.");
        }
    }
}
