using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace ConsoleClient
{
    class Program
    {
        /// <summary>
        /// Порт.
        /// </summary>
        const int port = 8888;
        /// <summary>
        /// IP-адрес.
        /// </summary>
        const string address = "127.0.0.1";
        static void Main(string[] args)
        {
            Console.Write("Введите свое имя:");
            /// <summary>
            /// Имя игрока.
            /// </summary>
            string userName = Console.ReadLine();
            
            TcpClient client = null;
            try
            {
                client = new TcpClient(address, port);
                NetworkStream stream = client.GetStream();

                while (true)
                {
                    Console.Write(userName + ": ");
                    /// <summary>
                    /// Сообщение игрока отправляемое на сервер.
                    /// </summary>
                    string message = Console.ReadLine();
                    message = String.Format("{0}: {1}", userName, message);
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
