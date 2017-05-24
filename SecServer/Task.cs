﻿using System;
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
        /// Кол-во готовых к игре игроков.
        /// </summary>
        public byte _ready = 0;
        
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
            
            
            bool _chek = false;
            bool _death = false;
         
                if (message.IndexOf('#') == 0)
                {
                    client.userName = message.Substring(1);
                    Console.Write(client.userName);
                }
            if (message.Equals("*"))
                _ready++;
                               
            if (ConsoleServer.Program.Ready(_ready).Equals(true))
            {
                ConsoleServer.Program.SendList();
                while (true)
                {
                    client.Client.Send(Encoding.Default.GetBytes("mafiaturn"));
                    if (message == "markhasbeenmade")
                    {
                        //запомнить помеченного клиента.
                        client.Client.Send(Encoding.Default.GetBytes("medicturn"));
                    }

                    if (message == "heal")
                    {
                        //снять метку с клиента если она на нём есть.
                        client.Client.Send(Encoding.Default.GetBytes("commissarturn"));
                    }

                    if (message == "chek")
                    {
                        //Сообщить комиссару мафия ли указанный игрок.
                        _chek = true;
                    }
                    if (_chek == true)
                    {
                        client.Client.Send(Encoding.Default.GetBytes("day"));
                        _chek = false;
                    }
                    if (message == "chekme")
                    {
                        //проверяется есть ли метка, если есть, то клиент отсоединяется
                        _death = true;
                    }
                    if (_death == true)
                    {
                        //метод кторые оповещает каждого клиента о результатах хода, а так же отправляе всем клиентам сообщение о начале голосования.
                        _death = false;
                    }
                    else
                    {
                        //метод который оповещает всех о результатах хода, а так же отправляе всем клиентам сообщение о начале голосования.
                    }
                    if (message.IndexOf("|") == 0)
                    {
                        //Считывается имя клиента после | и этому клиенту начисляется голос.
                    }
                    if (/*Все проголосовали*/true)
                    {
                        /*Метод считающий голоса*/
                        //ОТсоединяется от сервера игрок и всем рассылается сообщение об этом.
                        if (/**Проверка состояния партии*/true)
                        {
                            //Если игра окончена каким-либо рузультатом, то игра заканчивается.
                        }
                        else
                        {
                            client.Client.Send(Encoding.Default.GetBytes("mafiaturn"));
                        }
                    }
                }
            }
            Program.Print("Клиент {0} прислал сообщение: {1}", client.Client.RemoteEndPoint, client.userName);
            client.Client.Send(Encoding.Default.GetBytes("Ваша заявка принята"));
        }

    }
}
