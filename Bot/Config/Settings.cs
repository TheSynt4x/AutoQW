using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Config
{
    public class Settings
    {
        public static readonly IPAddress Address = IPAddress.Parse("167.114.11.56");
        public const ushort Port = 5588;

        public static string LoginUrl = "http://aqworldscdn.aq.com/game/cf-userlogin.asp";
        public static string SignupUrl = "http://173.214.160.41/game/cf-usersignup.asp";
    }
}
