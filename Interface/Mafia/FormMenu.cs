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
using ClassLibrary;

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
        static object locker = new object();

        Status status = new Status();



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
                byte[] data = Encoding.Default.GetBytes("##" + _client.userName);
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
        /// Настройки игры, отправка сообщения серверы о готовности игроков
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (boxsound.Text == "Звук")
            {
                Sound.Play_fail();
            }
            byte[] data = Encoding.Default.GetBytes("**");
            _client._socket.Send(data);

            pnlGame.Show();

        }

        private void _clientReaction()
        {
            byte[] c_answer = new byte[1024];
            //Буфер для ответа.
            //    byte[] answer = new byte[1024];
            //StringBuilder _str = new StringBuilder();
            //int bytes = 0;
            //string message = null;
            while (true)
            {
                if (_client._socket.Available == 0)
                {
                    Thread.Sleep(10);
                    continue;
                }
                c_bytes = _client._socket.Receive(c_answer);
                c_message = Encoding.Default.GetString(c_answer, 0, c_bytes).Replace("\0", "");
                //ListOfPlayers.Items.AddRange(message.Substring())
                if (c_message.Equals(string.Empty))
                    continue;
                switch (c_message.Substring(0, 2))
                {
                    case "==":
                        AddToPlayersList(c_message.Substring(2));
                        break;
                    case "@@":
                        if (c_message.Substring(2).Equals("mafia"))
                        {
                            _client.role = Role.Mafia;
                            MessageBox.Show("Вы - Мафийя!");
                        }
                        if (c_message.Substring(2).Equals("commissar"))
                        {
                            _client.role = Role.Commissar;
                            MessageBox.Show("Вы - Комиссар!");
                        }
                        if (c_message.Substring(2).Equals("doctor"))
                        {
                            _client.role = Role.Doctor;
                            MessageBox.Show("Вы - ДОтор!");
                        }
                        if (c_message.Substring(2).Equals("civilian"))
                        {
                            _client.role = Role.Civilian;
                            MessageBox.Show("Вы - МИрный Житель!!");
                        }
                        break;
                    case "mt":
                        status = Status.MafiaTurn;
                        btnOk.Visible = false;
                        if (_client.role.Equals(Role.Mafia))
                            btnOk.Visible = true;
                        break;
                    case "dt":
                        status = Status.DoctorTurn;
                        btnOk.Visible = false;
                        if (_client.role.Equals(Role.Doctor))
                            btnOk.Visible = true;
                        break;
                    case "ct":
                        status = Status.CommissarTurn;
                        btnOk.Visible = false;
                        if (_client.role.Equals(Role.Commissar))
                            btnOk.Visible = true;
                        break;
                    case "ym":
                        if (_client.role.Equals(Role.Commissar))
                            MessageBox.Show("Игрок " + c_message.Substring(2) + " ЯВЛЯЕТСЯ Мафией!");
                        break;
                    case "nm":
                        if (_client.role.Equals(Role.Commissar))
                            MessageBox.Show("Игрок " + c_message.Substring(2) + " НЕ Мафиея.");
                        break;
                    case "db":
                        if (c_message.Substring(2).Equals("no"))
                        {
                            status = Status.Day;
                            MessageBox.Show("Наступил день. Пострадавших НЕТ. Доктор отлично справляется со своей работой.  Приступай к голосованию.");
                            btnOk.Visible = true;
                        }
                        else
                        {
                            status = Status.Day;
                            MessageBox.Show("Наступил день. Игрок " + c_message.Substring(2) + " мёртв! Приступай к голосованию.");
                            btnOk.Visible = true;
                        }
                        break;
                    case "ve":
                        MessageBox.Show("По результатам голосования выбывает игрок: " + c_message.Substring(2));
                        break;
                    case "mw":
                        MessageBox.Show("Победу одержал Мафия! Конец игры!");
                        Thread.Sleep(6000);
                        _client._socket.Disconnect(false);
                        break;
                    case "cw":
                        MessageBox.Show("Победу одержали Мирные Жители! Конец игры!");
                        Thread.Sleep(6000);
                        _client._socket.Disconnect(false);
                        break;
                }
            }

        }

        private delegate void AddToPlayersListDelegate(string _name);

        private void AddToPlayersList(string _name)
        {
            if (ListOfPlayers.InvokeRequired)
            {
                ListOfPlayers.Invoke((AddToPlayersListDelegate)AddToPlayersList, _name);
                return;
            }
            ListOfPlayers.Items.Add(_name);
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
            switch (_client.role)
            {
                case Role.Civilian:
                    MessageBox.Show("Ж", "Роль", MessageBoxButtons.OK);
                    break;
                case Role.Commissar:
                    MessageBox.Show( "К", "Роль", MessageBoxButtons.OK);
                    break;
                case Role.Doctor:
                    MessageBox.Show( "В", "Роль", MessageBoxButtons.OK);
                    break;
                case Role.Mafia:
                    MessageBox.Show("М", "Роль", MessageBoxButtons.OK);
                    break;

            }
        }

        /// <summary>
        /// Обработка нажатия кнопки "Выбрать" в зависимости от текущего статуса.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            switch (status)
            {
                case Status.MafiaTurn:
                    data = Encoding.Default.GetBytes("mm" + ListOfPlayers.SelectedItem);
                    _client._socket.Send(data);
                    break;
                case Status.DoctorTurn:
                    data = Encoding.Default.GetBytes("hm" + ListOfPlayers.SelectedItem);
                    _client._socket.Send(data);
                    break;
                case Status.CommissarTurn:
                    data = Encoding.Default.GetBytes("cc" + ListOfPlayers.SelectedItem);
                    _client._socket.Send(data);
                    break;
                case Status.Day:
                    data = Encoding.Default.GetBytes("vv" + ListOfPlayers.SelectedItem);
                    _client._socket.Send(data);
                    break;
            }
        }
    }
}
