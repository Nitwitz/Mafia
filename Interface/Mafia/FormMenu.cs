using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Mafia
{
    

    /// <summary>
    /// Меню, окрывается при запуске
    /// </summary>
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
            buttoexit.BackColor = Color.Transparent;
            buttonabout.BackColor = Color.Transparent;
            buttonstart.BackColor = Color.Transparent;
            

        }
        /// <summary>
        /// Обработка входящих сообщений.
        /// </summary>
        private Thread _clientThread;
        /// <summary>
        /// Клиент.
        /// </summary>
        public Client.Client _client = new Client.Client();


        /// <summary>
        /// Выход из игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttoexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// Включение и выключение звука
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void boxsound_CheckedChanged(object sender, EventArgs e)
        {
            if (boxsound.Checked)
            {
                Sound.sound_on();
                boxsound.Text = "Звук";

            }
            else
            {
                Sound.sound_off();
                boxsound.Text = "Без звука";
            }
        }

       

        /// <summary>
        /// Кнопка запуска игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonstart_Click(object sender, EventArgs e)
        {

            Play play = new Play();
            if (play.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _client.userName = play.UserName;
                _client._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _client._socket.Connect(play.Address, int.Parse(play.Port));
                _clientThread = new Thread(new ThreadStart(_clientReaction));
                _clientThread.Start();


                  byte[] data = Encoding.Unicode.GetBytes("#"+_client.userName);
                 _client._socket.Send(data);
                
            }
        }
        /// <summary>
        /// Кнопка информации об игре
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonabout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Данное приложение созданно для замены ведущего в игре мафия  ", "Информация о игре", MessageBoxButtons.OK);

        }
        /// <summary>
        /// //
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            Lead lead = new Lead();
            byte[] data = Encoding.Unicode.GetBytes("*");
            _client._socket.Send(data);
            lead.Show();
        }

        private void _clientReaction()
        {
             /// <summary>
                /// Буфер для ответа.
                /// </summary> 
                byte[] answer = new byte[1024];
                StringBuilder _str = new StringBuilder();
                int bytes = 0;
                string message = null;

            do
            {
                bytes = _client._socket.Receive(answer, answer.Length, 0);
                message = _str.Append(Encoding.ASCII.GetString(answer, 0, bytes)).ToString();
                if (message == "new")
                {
                    //
                }
                if (message.Substring(0, 1).Equals("N|"))
                    //Lead.AddToList(message.Substring(2));
                if (message == "mafiaturn")
                {
                    //
                }
                if (message == "medicturn")
                {
                    //
                }
                if (message == "commissarturn")
                {
                    //
                }
                if (message == "day")
                {
                    //
                }
            }
            while (_client._socket.Available > 0);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            pnlGame.Hide();
        }
    }
}
