using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using Log;
using ClassLibrary;





namespace ConsoleServer
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
                    _client.Client.Send(Encoding.Default.GetBytes("new"));

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
}