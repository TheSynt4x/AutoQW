using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPluginTest
{
    public partial class TestForm : Form
    {
        private string _pluginName;

        private string _pluginDescription;

        public TestForm(string name, string desc)
        {
            InitializeComponent();

            _pluginName = name;
            _pluginDescription = desc;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            lblPluginName.Text += _pluginName;
            lblPluginDescription.Text += _pluginDescription;
        }
    }
}
