using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
/*using Log;*/
using ClassLibrary;





namespace Server
{
    class Program
    {
        /// <summary>
        /// Вывод в консоль.
        /// </summary>
        /// <param name="f">Формат.</param>
        /// <param name="p">Параметры.</param>
        public static void Print(string f, params object[] p)
        {
            Console.WriteLine(f, p);
        }


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


        static object locker = new object();

        static void Main(string[] args)
        {
            //string[] _args = (string[])args;
            IPAddress _ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint _ipep = new IPEndPoint(_ip, 1000);
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
                    players.Client.Send(Encoding.Default.GetBytes("=" + _players.userName));

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
            Random _rnd = new Random();
            byte _mafiaIndex = (byte)_rnd.Next(1, _cCount);
            byte _commissarIndex = (byte)_rnd.Next(1, _cCount);
            byte _medicIndex = (byte)_rnd.Next(1, _cCount);
            byte _clientCount = 1;
            foreach (SClient client in clients)
            {
                if (_clientCount == _mafiaIndex)
                {
                    client.role = Role.Mafia;
                    client.Client.Send(Encoding.Default.GetBytes("@mafia"));
                }
                else
                    if (_clientCount == _commissarIndex)
                {
                    client.role = Role.Commissar;
                    client.Client.Send(Encoding.Default.GetBytes("@commissar"));
                }
                else
                    if (_clientCount == _medicIndex)
                {
                    client.role = Role.Doctor;
                    client.Client.Send(Encoding.Default.GetBytes("@doctor"));
                }
                else
                {
                    client.role = Role.Civilian;
                    client.Client.Send(Encoding.Default.GetBytes("@civilian"));
                }
                _clientCount++;
            }
        }

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
                        client.Client.Send(Encoding.Default.GetBytes("mw"));
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
                    client.Client.Send(Encoding.Default.GetBytes("cw"));
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
                if (_name.Equals(client.userName) & client.role.Equals(Role.Mafia))
                    client.Client.Send(Encoding.Default.GetBytes("ym"));

                else
                    client.Client.Send(Encoding.Default.GetBytes("nm"));
        }

        /// <summary>
        /// Наступление дня. Проверка на налдичие мёртвых.
        /// </summary>
        public static void DayBeginning()
        {
            foreach (SClient client in clients)
            {
                if (client.mark == true)
                {
                    foreach (SClient _client in clients)
                        _client.Client.Send(Encoding.Default.GetBytes("db"+client.userName));
                    client.Client.Disconnect(false);
                    break;
                }
            }
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
            foreach (SClient client in clients)
            {
                if (client.voteCount == MaxVotes())
                {
                    foreach (SClient _client in clients)
                        _client.Client.Send(Encoding.Default.GetBytes("ve" + client.userName));
                    client.Client.Disconnect(false);
                    break;
                }
            }
        }

        
    }
}