using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ConsoleClient
{
    public class Client
    {
        /// <summary>
        /// Порт.
        /// </summary>
        const int port = 8888;
        /// <summary>
        /// IP-адрес.
        /// </summary>
        const string address = "127.0.0.1";

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
        /// Результат голосования.
        /// </summary>
        public bool voteResult = false;]

        static void Main(string[] args)
        {
           

            TcpClient client = null;
            try
            {
               
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();
                
                while (true)
                {
                    Console.Write(" ");
                    /// <summary>
                    /// Сообщение игрока отправляемое на сервер.
                    /// </summary>
                    string message = Console.ReadLine();
                    /// <summary>
                    /// Преобразуем сообщение в массив байтов.
                    /// </summary>
                    byte[] data = Encoding.Unicode.GetBytes(message);
                    /// <summary>
                    /// Отправка сообщения.
                    /// </summary>
                    stream.Write(data, 0, data.Length);

                    data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    /// <summary>
                    /// Получение ответа от сервера.
                    /// </summary>
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    message = builder.ToString();
                    Console.WriteLine("Сервер: {0}", message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }
        }
    }
}