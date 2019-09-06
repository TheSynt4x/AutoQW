using Bot.Game;
using Bot.Managers.Commands;
using Bot.Managers.Plugins;
using Bot.Network.Packets;
using Bot.Plugins;
using Bot.Terminal;
using BotPluginChat.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPluginChat
{
    [BotPluginEntry]
    class Loader : IBotPlugin
    {
        public string Name { get; } = "Chat Plugin";

        public string Description { get; } = "Adds a commands for the in-game chat.";

        private Chat _chatForm;

        private ICommandHandle _plugin;
        private List<IXtPacketHandler> _packets = new List<IXtPacketHandler>();

        public void Load()
        {
            _plugin = new ChatPlugin();

            var chat = new Chatm();

            chat.OnMessage += _chatForm.OnMessage;

            _packets.Add(chat);
            _packets.Add(new Uotls());

            BotTerminal.Instance.RegisterCommand(_plugin);

            foreach (var packet in _packets)
                Player.Client.RegisterHandler(packet);
                
            _chatForm = new Chat();

            Thread mThread = new Thread(delegate ()
            {
                _chatForm.ShowDialog();
            });

            mThread.SetApartmentState(ApartmentState.STA);

            mThread.Start();
        }

        public void Unload()
        {
            BotTerminal.Instance.UnregisterCommand(_plugin);

            if (Player.IsLoggedIn)
                foreach (var packet in _packets)
                    Player.Client.UnregisterHandler(packet);
            else Console.WriteLine($"User {Player.Client.Username} is not online.");
        }
    }
}
