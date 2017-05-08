using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Threading;

namespace ConsoleServer
{
    /// <summary>
    /// Класс, описывающий задачу.
    /// </summary>
   public class Task
    {
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
        public static void AddToQueue(Socket client, string message)
        {
            taskQueue.Enqueue(new Task(client, message));
        }
        /// <summary>
        /// Сообщение, полученное от клиента.
        /// </summary>
        private string message;
        /// <summary>
        /// Сокет клиента.
        /// </summary>
        private Socket client;
        /// <summary>
        /// Инициализирует экземпляр класса Task.
        /// </summary>
        /// <param name="client">Сокет клиента.</param>
        /// <param name="message">Сообщение, полученное от клиента.</param>
        private Task(Socket client, string message)
        {
            this.client = client;
            this.message = message;
        }
        /// <summary>
        /// Выполняет задачу, сформированную на основе данных, полученных от клиента.
        /// </summary>
        public void Solve()
        {
            Program.Print("Клиент {0} прислал сообщение: >>>{1}<<<", client.RemoteEndPoint, message);
            client.Send(Encoding.Default.GetBytes("Ваша заявка принята"));
        }

    }
}
