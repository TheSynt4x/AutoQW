using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Util
{
    class InputHandler
    {
        public static T GetInput<T>(string msg) where T : IConvertible
        {
            Console.Write(msg);
            return (T) Convert.ChangeType(Console.ReadLine(), typeof(T));
        }
    }
}
