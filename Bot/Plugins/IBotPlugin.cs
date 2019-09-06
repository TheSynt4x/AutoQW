using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Managers.Plugins
{
    public interface IBotPlugin
    {
        string Name { get; }
        string Description { get; }
        void Load();
        void Unload();
    }
}
