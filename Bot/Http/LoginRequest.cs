using Bot.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bot.Http
{
    public class LoginRequest
    {
        public static async Task<string> GetUserToken(string username, string password)
        {
            using (var handler = new HttpClient()) {
                XmlDocument x = new XmlDocument();

                x.LoadXml(await handler.PostAsync(Settings.LoginUrl, new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "unm", username },
                    { "pwd", password }
                })).Result.Content.ReadAsStringAsync());

                return x["login"].Attributes["sToken"].Value;
            }
        }
    }
}
