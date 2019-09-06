using Bot.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Game
{
    public static class Player
    {
        public static Client Client { get; set; }

        public static int UserId { get; set; }

        public static bool IsLoggedIn { get; set; } = false;

        public static string FollowTarget { get; set; }

        public static string CopyTarget { get; set; }

        public static string LastCell { get; set; }
    }
}
