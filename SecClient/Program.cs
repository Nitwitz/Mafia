using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Threading;
using ClassLibrary;

namespace Client
{
    class Program
    {
        /// <summary>
        /// Порт сервера.
        /// </summary>
        private static int port = 1000;
        /// <summary>
        /// Адрес сервера.
        /// </summary>
        private static IPAddress address = IPAddress.Parse("127.0.0.1");

        /// <summary>
        /// Имя игрока.
        /// </summary>
        public string userName;
        /// <summary>
        /// Роль игрока.
        /// </summary>
        public Role role;
        /// <summary>
        /// Метка указывающая на то, что на игрока указал Мафия.
        /// </summary>
        public bool mark = false;
        /// <summary>
        /// Счётчик голосования.
        /// </summary>
        public byte voteCount = 0;
        /// <summary>
        /// Максимальное число голосов.
        /// </summary>
        public byte voteMax = 0;

        static void Main(string[] args)
        {
            try
            {
                /// <summary>
                /// Создаем удаленную точку.
                /// </summary>
                IPEndPoint ipPoint = new IPEndPoint(address, port);
                /// <summary>
                /// Создаем сокет.
                /// </summary>
                Socket _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                /// <summary>
                /// Подключаемся к удаленной точке.
                /// </summary> 
                _socket.Connect(ipPoint);
                Console.Write("Введите сообщение:");
                /// <summary>
                /// Вводим сообщение.
                /// </summary> 
                string _mess = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(_mess);
                /// <summary>
                /// Отправляем данные через сокет.
                /// </summary> 
                _socket.Send(data);

                /// <summary>
                /// Буфер для ответа.
                /// </summary> 
                data = new byte[1024];
                StringBuilder _str = new StringBuilder();
                int bytes = 0;
                /// <summary>
                /// Получаем ответ от сервера.
                /// </summary>
                do
                {
                    bytes = _socket.Receive(data, data.Length, 0);
                    _str.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (_socket.Available > 0);
                Console.WriteLine("Ответ: " + _str.ToString());
                /// <summary>
                /// Закрываем сокет.
                /// </summary>
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}