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
            btnStart.BackColor = Color.Transparent;

        }

        byte[] c_answer = new byte[1024];
        StringBuilder c_str = new StringBuilder();
        int c_bytes = 0;
        string c_message = null;
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
                boxsound.Text = "Нет";
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
                byte[] data = Encoding.Default.GetBytes("#" + _client.userName);
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
            DialogResult result = MessageBox.Show("Данное приложение созданно для замены ведущего в игре мафия  ", "Информация о игре",MessageBoxButtons.OK);
        }
        /// <summary>
        /// Настройки игры, отправка сообщения серверы о готовности игроков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if(boxsound.Text == "Звук")
            {
                Sound.Play_fail();    
            }
                byte[] data = Encoding.Default.GetBytes("*");
                _client._socket.Send(data);
                
                pnlGame.Show();
            
        }

        private void _clientReaction()
        {

            //Буфер для ответа.
            //    byte[] answer = new byte[1024];
            //StringBuilder _str = new StringBuilder();
            //int bytes = 0;
            //string message = null;

            do
            {
                c_bytes = _client._socket.Receive(c_answer, c_answer.Length, 0);
                c_message = c_str.Append(Encoding.Default.GetString(c_answer, 0, c_bytes)).ToString();
                //ListOfPlayers.Items.AddRange(message.Substring())
                if (c_message == "new")
                {
                    //
                }
                if (c_message.Substring(0, 1).Equals("="))
                {
                    byte[] data = Encoding.Default.GetBytes("mes");
                    _client._socket.Send(data);
                    //ListOfPlayers.Items.Add(c_message.Substring(2));
                }
                if (c_message == "mafiaturn")
                {
                    //
                }
                if (c_message == "medicturn")
                {
                    //
                }
                if (c_message == "commissarturn")
                {
                    //
                }
                if (c_message == "day")
                {
                    //
                }
            }
            while (_client._socket.Available > 0);
        }
        /// <summary>
        /// Отображает кнопку выбора, список игроков, и текущую роль
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMenu_Load(object sender, EventArgs e)
        {
            pnlGame.Hide();
        }
        /// <summary>
        /// Правила игры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInfo_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(" ", "Правила игры", MessageBoxButtons.OK);
        }
    }
}
