using Bot.Game;
using Bot.Managers.Commands;
using Bot.Network.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotPluginChat
{
    class ChatPlugin : ICommandHandle
    {
        public string HandledCommand { get; } = "!user";

        public void Handle(string[] cmd)
        {
            switch (cmd[1]) {
                case "say":
                    Player.Client.Write($"%xt%zm%message%{World.RoomId}%{string.Join(" ", cmd.Skip(2).ToArray())}%zone%");
                    break;
                case "house":
                    break;
                case "emote":
                    Player.Client.Write($"%xt%zm%emotea%1%{cmd[2]}%");
                    break;
                case "goto":
                    Player.Client.Write($"%xt%zm%cmd%1%goto%{cmd[2]}%");
                    break;
                case "join":
                    Player.Client.Write($"%xt%zm%cmd%1%tfer%{Player.Client.Username}%{cmd[2]}%");
                    Player.Client.Write($"%xt%zm%moveToCell%{World.RoomId}%Enter%Spawn%");
                    Player.Client.Write($"%xt%zm%setHomeTown%{World.RoomId}%");
                    break;
                case "follow":
                    Player.FollowTarget = cmd[2];
                    break;
                case "copy":
                    Player.CopyTarget = cmd[2];
                    break;
                case "cell":
                    Player.Client.Write($"%xt%zm%moveToCell%{World.RoomId}%{cmd[2]}%{cmd[3]}%");
                    Player.LastCell = cmd[2];
                    break;
            }
        }
    }
}
