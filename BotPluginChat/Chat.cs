using Bot.Game;
using Bot.Managers.Commands;
using Bot.Network.Packets;
using Bot.Terminal;
using BotPluginChat.Packets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotPluginChat
{
    public partial class Chat : Form
    {
        public Chat()
        {
            InitializeComponent();
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                e.SuppressKeyPress = true;

                richTextBox1.AppendText(Player.Client.Username + ": " + textBox1.Text + "\n");

                Player.Client.Write($"%xt%zm%message%{World.RoomId}%{textBox1.Text}%zone%");

                textBox1.Text = "";
            }
        }

        public void OnMessage(string user, string message)
        {
            richTextBox1.AppendText(user + ": " + message + "\n");
        }

        private void Chat_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) {
                e.Cancel = true;

                MessageBox.Show("Cannot be closed. Must be unloaded.");
            }
        }
    }
}
