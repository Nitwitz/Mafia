using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using ClassLibrary;


namespace Server
{
    /// <summary>
    /// Класс, описывающий задачу.
    /// </summary>
    public class Task
    {

        static object locker = new object();


        /// <summary>
        /// Сообщение, полученное от клиента.
        /// </summary>
        private string message;
        /// <summary>
        /// Сокет клиента.
        /// </summary>
        private SClient client;
        /// <summary>
        /// Поток обработки сообщений от клиентов.
        /// </summary>
        private static Thread queueThread;
        /// <summary>
        /// Очередь сообщений от клиентов.
        /// </summary>
        private static Queue<Task> taskQueue = new Queue<Task>();
        /// <summary>
        /// Запускает поток обработки сообщений от клиентов.
        /// </summary>
        public static void RunQueueThread()
        {
            queueThread = new Thread(new ThreadStart(ThreadQueue));
            queueThread.IsBackground = true;
            queueThread.Start();
        }
        /// <summary>
        /// Поток работы с очередью.
        /// </summary>
        private static void ThreadQueue()
        {
            while (true)
            {
                if (taskQueue.Count > 0)
                    taskQueue.Dequeue().Solve();
                else
                    Thread.Sleep(5);
            }
        }
        /// <summary>
        /// Добавляет задание в очередь.
        /// </summary>
        /// <param name="client">Сокет клиента.</param>
        /// <param name="message">Сообщение, полученное от клиента.</param>
        public static void AddToQueue(SClient client, string message)
        {
            taskQueue.Enqueue(new Task(client, message));
        }

        /// <summary>
        /// Инициализирует экземпляр класса Task.
        /// </summary>
        /// <param name="client">Сокет клиента.</param>
        /// <param name="message">Сообщение, полученное от клиента.</param>
        private Task(SClient client, string message)
        {
            this.client = client;
            this.message = message;
        }

        /// <summary>
        /// Выполняет задачу, сформированную на основе данных, полученных от клиента.
        /// </summary>
        public void Solve()
        {
            switch (message.Substring(0, 2))
            {
                case "##":
                    Server.Program.SameName(message.Substring(2));
                    if (Turns.sameName == true)
                    {
                        client.userName = message.Substring(2) + "*";
                        client.Client.Send(Encoding.Default.GetBytes("++"));
                    }
                    else
                        client.userName = message.Substring(2);
                    Program.Print(client.userName);
                    Turns.sameName = false;
                    break;

                case "**":
                    Turns._ready++;
                    Program.Print("op Ready " + Turns._ready.ToString());
                    if (Server.Program.Ready(Turns._ready).Equals(true))
                    {
                        Program.Print("Sending");
                        Server.Program.SendList();
                        Thread.Sleep(1000);
                        Server.Program.Cast();
                        Thread.Sleep(5000);
                        Server.Program.SendMT();
                        Turns._ready = 0;
                    }
                    break;
                case "mm":
                    Server.Program.MarkM(message.Substring(2));
                    Thread.Sleep(2000);
                    Server.Program.SendDT();
                    break;

                case "hm":
                    Server.Program.Heal(message.Substring(2));
                    Thread.Sleep(2000);
                    Server.Program.SendCT();
                    break;
                case "cc":
                    Server.Program.CommisarChek(message.Substring(2));
                    Thread.Sleep(6000);
                    Server.Program.DayBeginning();
                    break;
                case "cg":
                    Server.Program.DayBeginning();
                    break;
                case "vv":
                    Server.Program.Vote(message.Substring(2));
                    if (Server.Program.AllVoted(Turns._voted).Equals(true))
                    {
                        Server.Program.Voting();
                        Thread.Sleep(6000);
                        Server.Program.Check();
                    }
                    break;
            }
            Program.Print("Клиент {0} прислал сообщение: >{1}<", client.Client.RemoteEndPoint, message);
        }
    }
}
