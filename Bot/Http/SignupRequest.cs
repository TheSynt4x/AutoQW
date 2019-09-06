using Bot.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Http
{
    public class SignupRequest
    {
        public static async void RegisterUser(string username, string password)
        {
            CookieContainer cc = new CookieContainer();

            using (var cookie = new HttpClientHandler { CookieContainer = cc })
            using (var handler = new HttpClient(cookie)) {
                var result = await handler.PostAsync(Settings.SignupUrl, new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "ClassID", "2" },
                    { "HairID", "52" },
                    { "intAge", "68" },
                    { "intColorEye", "91294" },
                    { "intColorHair", "6180663" },
                    { "intColorSkin", "15388042" },
                    { "strDOB", "3/19/1950" },
                    { "strEmail", $"{username}@bitwhites.top" },
                    { "strGender", "M" },
                    { "strPassword", password },
                    { "strUsername", username }
                })).Result.Content.ReadAsStringAsync();

                Console.WriteLine(result);

                var status = result.Contains("status=Success") ? "was successfully" : "was not";

                Console.WriteLine($"Username {username} {status} created.");
            }
        }
    }
}
