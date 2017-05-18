using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using ClassLibrary;

namespace ConsoleServer
{
    /// <summary>
    /// Класс, описывающий задачу.
    /// </summary>
   public class Task
    {

        /// <summary>
        /// Сообщение, полученное от клиента.
        /// </summary>
        private string message;
        /// <summary>
        /// Сокет клиента.
        /// </summary>
        private Socket client;
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
            bool _mhbm = false;           //<--мафия сделала свой выбор.
            bool _heal = false;
            bool _chek = false;
            bool _death = false;
            if(message.IndexOf('#')==0)
            {
                 //присовить имя клиенту, которое начинается со знака #
            }
            if(/*Все клиенты нажали кнопку Готов*/ true) 
            {
                while (true)
                {
                    client.Send(Encoding.Default.GetBytes("mafiaturn"));
                    if(message == "markhasbeenmade")
                    {
                        //запомнить помеченного клиента.
                        _mhbm = true;
                    }
                    if(_mhbm==true)
                        client.Send(Encoding.Default.GetBytes("medicturn"));

                    if(message=="heal")
                    {
                        //снять метку с клиента если она на нём есть.
                        _heal = true;
                    }
                    if(_heal==true)
                        client.Send(Encoding.Default.GetBytes("commissarturn"));
                    if(message=="chek")
                    {
                        //Сообщить комиссару мафия ли указанный игрок.
                        _chek = true;
                    }
                    if(_chek==true)
                        client.Send(Encoding.Default.GetBytes("day"));
                    if (message == "chekme")
                    {
                        //проверяется есть ли метка, если есть, то клиент отсоединяется
                        _death = true;
                    }
                    if(_death ==true)
                    {
                        //метод кторые оповещает каждого клиента о результатах хода, а так же отправляе всем клиентам сообщение о начале голосования.
                    }
                    else
                    {
                        //метод который оповещает всех о результатах хода, а так же отправляе всем клиентам сообщение о начале голосования.
                    }
                    if(message.IndexOf("|")==0)
                    {
                        //Считывается имя клиента после | и этому клиенту начисляется голос.
                    }
                    if(/*Все проголосовали*/true)
                    {
                        /*Метод считающий голоса*/
                        //ОТсоединяется от сервера игрок и всем рассылается сообщение об этом.
                        if(/**Проверка состояния партии*/true)
                        {
                            //Если игра окончена каким-либо рузультатом, то игра заканчивается.
                        }
                        else
                        {
                            client.Send(Encoding.Default.GetBytes("mafiaturn"));
                        }
                    }
                }
            }
            Program.Print("Клиент {0} прислал сообщение: >>>{1}<<<", client.RemoteEndPoint, message);
            client.Send(Encoding.Default.GetBytes("Ваша заявка принята"));
        }

    }
}
