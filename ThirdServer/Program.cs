#define CS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using System.Windows.Forms;
/*using Log;*/
using ClassLibrary;
using System.IO;





namespace Server
{
    public class Program
    {
        /// <summary>
        /// Вывод в консоль.
        /// </summary>
        /// <param name="f">Формат.</param>
        /// <param name="p">Параметры.</param>

        public static void Print(string f, params object[] p)
        {
#if CS
            Console.WriteLine(f, p);
#endif
        }

        static string port;
        /// <summary>
        /// Сервер.
        /// </summary>
        private static TcpListener tcpServer;
        /// <summary>
        /// Массив, содержащий подключения клиентов.
        /// </summary>
        public static List<SClient> clients = new List<SClient>();
        /// <summary>
        /// Поток проверки доступности клиентов.
        /// </summary>
        private static Thread checkThread;
        /// <summary>
        /// Поток получения данных от клиентов.
        /// </summary>
        private static Thread receiveThread;
        //private static ILog _log = new FileLog("X:\\123.txt");

        public static Random _rnd = new Random();

        static object locker = new object();

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                port = "1100";
            }
            else
            {
                port = args[0];
            }
               MainTH((object)args);
        }

        public static void MainTH(object args)
        { 

            string[] _args = (string[])args;
            int serverPort = Convert.ToInt32(port);
            string serverAdress = Dns.GetHostName(); 
               

            IPAddress _ip = Dns.GetHostByName(serverAdress).AddressList[0];
            
            IPEndPoint _ipep = new IPEndPoint(_ip, serverPort);
            //_log.WriteEntry("MyServer", "Сервер запускается.", LogEventType.Info);
            tcpServer = new TcpListener(_ipep);
            tcpServer.Start();
            SClient _client;

            checkThread = new Thread(new ThreadStart(check));
            checkThread.IsBackground = true;
            checkThread.Start();
            receiveThread = new Thread(new ThreadStart(receive));
            receiveThread.IsBackground = true;
            receiveThread.Start();


            Task.RunQueueThread();

            //_log.WriteEntry("MyServer", "Сервер успешно запущен.", LogEventType.Warning);

            while (true)
            {

                TcpClient c = tcpServer.AcceptTcpClient();
                _client = new SClient();
                _client.tcpClient = c;

                lock (clients)
                {
                    clients.Add(_client);

                }
                Print("Подключился новый клиент: {0}", _client.Client.RemoteEndPoint);

            }
        }

        /// <summary>
        /// Проверка наличия клиентов.
        /// </summary>
        private static void check()
        {
            SClient _client;
            while (true)
            {
                lock (clients)
                {
                    for (int i = 0; i < clients.Count; i++)
                    {
                        _client = clients[i];
                        try
                        {
                            _client.Client.Send(new byte[] { 0 });
                        }
                        catch (SocketException)
                        {
                            Print("Клиент более недоступен: {0}", _client.Client.RemoteEndPoint);
                            //_log.WriteEntry("MyServer", string.Format("Клиент более недоступен: {0}", _client.Client.RemoteEndPoint), LogEventType.Warning);
                            clients.Remove(_client);
                            i--;
                        }
                        catch { }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// помещение сообщения и информации о клиенте в очередь.
        /// </summary>
        private static void receive()
        {
            lock (locker)
            {
                SClient _client;
                byte[] _buff;
                string _mess = string.Empty;

                while (true)
                {

                    for (int i = 0; i < clients.Count; i++)
                    {
                        _client = clients[i];
                        try
                        {
                            if (_client.tcpClient.Available > 0)
                            {
                                _buff = new byte[_client.tcpClient.Available];
                                _client.Client.Receive(_buff);
                                _mess = Encoding.Default.GetString(_buff);
                                Task.AddToQueue(_client, _mess);
                            }
                        }
                        catch { }
                    }
                    Thread.Sleep(10);
                }
            }
        }

        /// <summary>
        /// Проверка готовности всех игроков.
        /// </summary>
        /// <returns></returns>
        public static bool Ready(byte ready)
        {
            if (ready == clients.Count)
            {
                Print("true");
                return true;
            }
            else
            {
                Print("false" + clients.Count.ToString());
                return false;
            }
        }

        /// <summary>
        /// Отправка каждому из киентов списка имён клиентов.
        /// </summary>
        public static void SendList()
        {

            Print("+");
            foreach (SClient players in clients)
            {
                Print("++");
                foreach (SClient _players in clients)
                {
                    Thread.Sleep(200);
                    Print("-");
                    players.Client.Send(Encoding.Default.GetBytes("==" + _players.userName));
                }
            }
        }


        /// <summary>
        /// Назначение игрокам ролей.
        /// </summary>
        /// <param name="clients">Список игроков.</param>
        public static void Cast()
        {
            byte _cCount = (byte)clients.Count;
            byte _mafiaIndex = (byte)_rnd.Next(1, _cCount+1);
            byte _commissarIndex = (byte)_rnd.Next(1, _cCount+1);
            while(_commissarIndex == _mafiaIndex)
                _commissarIndex = (byte)_rnd.Next(1, _cCount+1);
            byte _medicIndex = (byte)_rnd.Next(1, _cCount+1);
             while(_medicIndex == _mafiaIndex || _medicIndex== _commissarIndex)
                _medicIndex = (byte)_rnd.Next(1, _cCount+1);
            byte _clientCount = 1;
            foreach (SClient client in clients)
            {
                if (_clientCount == _mafiaIndex)
                {
                    client.role = Role.Mafia;
                    client.Client.Send(Encoding.Default.GetBytes("@@mafia"));
                }
                else
                    if (_clientCount == _commissarIndex )
                {
                    client.role = Role.Commissar;
                    client.Client.Send(Encoding.Default.GetBytes("@@commissar"));
                }
                else
                    if (_clientCount == _medicIndex)
                {
                    client.role = Role.Doctor;
                    client.Client.Send(Encoding.Default.GetBytes("@@doctor"));
                }
                else
                {
                    client.role = Role.Civilian;
                    client.Client.Send(Encoding.Default.GetBytes("@@civilian"));
                }
                _clientCount++;
            }
        }

        //public static void Cast2()
        //{
        //    byte[] players = new byte[clients.Count];
        //    for (byte i = 1; i <= players.Length; i++)
        //        players[i] = i;

        //    Random rand = new Random();
        //    for (int i = players.Length - 1; i >= 0; i--)
        //    {
        //        byte j = rand.Next(i);
        //        byte temp = players[i];
        //        players[i] = players[j];
        //        players[j] = temp;
        //    }
        //    byte _clientCount = 1;
        //    foreach (SClient client in clients)
        //    {
        //        if (_clientCount == 1)
        //        {
        //            client.role = Role.Mafia;
        //            client.Client.Send(Encoding.Default.GetBytes("@@mafia"));
        //        }
        //        else
        //            if (_clientCount == _commissarIndex)
        //        {
        //            client.role = Role.Commissar;
        //            client.Client.Send(Encoding.Default.GetBytes("@@commissar"));
        //        }
        //        else
        //            if (_clientCount == _medicIndex)
        //        {
        //            client.role = Role.Doctor;
        //            client.Client.Send(Encoding.Default.GetBytes("@@doctor"));
        //        }
        //        else
        //        {
        //            client.role = Role.Civilian;
        //            client.Client.Send(Encoding.Default.GetBytes("@@civilian"));
        //        }
        //        _clientCount++;
        //    }
        //}

        /// <summary>
        /// Проверка состояния партии.
        /// </summary>
        public static void Check()
        {
            byte _civCount = 0;
            bool _mafiaEx = false;
            foreach (SClient client in clients)
            {
                if (client.role == Role.Mafia)
                    _mafiaEx = true;
                if (client.role == Role.Civilian || client.role == Role.Commissar || client.role == Role.Doctor)
                    _civCount++;
            }
            if (_mafiaEx == true)
            {
                if (_civCount <= 2)
                {
                    foreach (SClient client in clients)
                    {
                        Turns._ready = 0;
                        client.Client.Send(Encoding.Default.GetBytes("mw"));
                    }
                }
                else
                {
                    foreach (SClient client in clients)
                        client.Client.Send(Encoding.Default.GetBytes("mt"));
                }
            }
            else
            {
                foreach (SClient client in clients)
                {
                    Turns._ready = 0;
                    client.Client.Send(Encoding.Default.GetBytes("cw"));
                }
            }
        }

        /// <summary>
        /// Запоминание клиента на которого пал выбор Мафии.
        /// </summary>
        /// <param -name="_name">Имя клиента на которого пал выбор мафии.</param>
        public static void MarkM(string _name)
        {
            foreach (SClient client in clients)
                if (_name.Equals(client.userName))
                    client.mark = true;
        }

        /// <summary>
        /// Лечение выбранного Доктором игрока.
        /// </summary>
        /// <param name="_name">имя выбранного для лечения игрока.</param>
        public static void Heal(string _name)
        {
            foreach (SClient client in clients)
                if (_name.Equals(client.userName))
                    client.mark = false;
        }

        /// <summary>
        /// Проверка указанного Коммисаром игрока. 
        /// </summary>
        /// <param name="_name">Имя выбранного Коммисаром игрока.</param>
        public static void CommisarChek(string _name)
        {
            foreach (SClient client in clients)
                if (_name.Equals(client.userName) && client.role.Equals(Role.Mafia))
                    Turns.guessed = true;
            if (Turns.guessed == true)
                foreach (SClient client in clients)
                    client.Client.Send(Encoding.Default.GetBytes("ym"+_name));
                else
                foreach (SClient client in clients)
                    client.Client.Send(Encoding.Default.GetBytes("nm" + _name));
        }

        /// <summary>
        /// Наступление дня. Проверка на наличие мёртвых.
        /// </summary>
        public static void DayBeginning()
        {
            foreach (SClient client in clients)
                if (client.mark == true)
                    Turns.corpse = true;
            if (Turns.corpse == true)
            {
                foreach (SClient _client in clients)
                {
                    if (_client.mark == true)
                    {
                        foreach (SClient client in clients)
                            client.Client.Send(Encoding.Default.GetBytes("db" + _client.userName));
                        Thread.Sleep(2000);
                        _client.Client.Disconnect(false);
                    }
                }
            }
            else
            {
                foreach (SClient _client in clients)
                    _client.Client.Send(Encoding.Default.GetBytes("dbno"));
            }
            Turns.corpse = false;
        }
            

        /// <summary>
        /// Начисление голосов.
        /// </summary>
        /// <param name="_name">Имя игрока против которого голосуют.</param>
        public static void Vote(string _name)
        {
            foreach (SClient client in clients)
                if (_name.Equals(client.userName))
                {
                    client.voteCount++;
                    Turns._voted++;
                }
        }

        /// <summary>
        /// Проверка, все ли игроки проголосовали.
        /// </summary>
        /// <param name="voted">Кол-во проголосовавших игроков.</param>
        /// <returns>Готовность всех игроков.</returns>
        public static bool AllVoted(byte voted)
        {
            if (voted == clients.Count)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Определение максимального числа голосов.
        /// </summary>
        /// <returns>Максимальное число голосов.</returns>
        public static byte MaxVotes()
        {
            byte max = 0;
            foreach (SClient client in clients)
            {
                if (client.voteCount > max)
                    max = client.voteCount;
            }
            return (max);
        }

        /// <summary>
        /// Голосование.
        /// </summary>
        public static void Voting()
        {
            byte count = 0;
            foreach (SClient client in clients)
                if (client.voteCount == MaxVotes())
                    count++;

                if (count > 1)
                    Turns.sameVotes = true;

            if (Turns.sameVotes == true)
                foreach (SClient client in clients)
                    client.Client.Send(Encoding.Default.GetBytes("vc"));
            else
                foreach (SClient client in clients)
                    if (client.voteCount == MaxVotes())
                        foreach (SClient _client in clients)
                        {
                            _client.Client.Send(Encoding.Default.GetBytes("ve" + client.userName));
                            client.Client.Disconnect(false);
                            Turns._voted = 0;
                        }
            Turns.sameVotes = false;
            foreach (SClient _client in clients)
                _client.voteCount = 0;
        }

        /// <summary>
        /// Отправка каждому из клиентов оповещение о начале хода Мафии.
        /// </summary>
        public static void SendMT()
        {
            foreach (SClient _client in clients)
                _client.Client.Send(Encoding.Default.GetBytes("mt"));
        }


        /// <summary>
        /// Отправка каждому из клиентов оповещение о начале хода Доктора.
        /// </summary>
        public static void SendDT()
        {
            bool _docex = false;
            foreach (SClient _client in clients)
                if (_client.role.Equals(Role.Doctor))
                    _docex = true;
            if (_docex == true)
                foreach (SClient _client in clients)
                    _client.Client.Send(Encoding.Default.GetBytes("dt"));
            else
                foreach (SClient _client in clients)
                    _client.Client.Send(Encoding.Default.GetBytes("dm"));
        }

        /// <summary>
        /// Отправка каждому из клиентов оповещение о начале хода Коммисара.
        /// </summary>
        public static void SendCT()
        {
            bool _comex = false;
            foreach (SClient _client in clients)
                if (_client.role.Equals(Role.Commissar))
                    _comex = true;
            if (_comex == true)
                foreach (SClient _client in clients)
                    _client.Client.Send(Encoding.Default.GetBytes("ct"));
                else
                foreach (SClient _client in clients)
                    _client.Client.Send(Encoding.Default.GetBytes("cm"));
        }

        /// <summary>
        /// Реакция на случай, когда введённое имя совпадает с уже существующим.
        /// </summary>
        /// <param name="_name">Введённое игроком имя.</param>
        public static void SameName(string _name)
        {
            foreach (SClient client in clients)
                if (_name.Equals(client.userName))
                    Turns.sameName = true;
        }
    }
}