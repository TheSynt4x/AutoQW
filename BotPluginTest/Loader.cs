using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot.Managers.Plugins;
using System.Windows.Forms;
using System.Threading;
using Bot.Plugins;

namespace BotPluginTest
{
    [BotPluginEntry]
    public class Loader : IBotPlugin
    {
        public string Name { get; } = "Test Plugin"; 
        public string Description { get; } = "This is a test plugin for bot.";

        private TestForm testForm;

        public void Load()
        {
            testForm = new TestForm(Name, Description);

            Thread mThread = new Thread(delegate ()
            {      
                testForm.ShowDialog();
            });

            mThread.SetApartmentState(ApartmentState.STA);

            mThread.Start();
        }

        public void Unload()
        {
            testForm.Hide();
        }
    }
}
