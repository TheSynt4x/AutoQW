using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot.Managers.Commands
{
    public interface ICommandHandle
    {
        string HandledCommand { get; }
        void Handle(string[] cmd);
    }
}
