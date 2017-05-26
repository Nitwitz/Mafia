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
    public class Client
    {


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
        public Socket _socket;
   
        static void Main(string[] args)
        {
            try
            {
                

                ///// <summary>
                ///// Вводим сообщение.
                ///// </summary> 
                //string _mess = Console.ReadLine();
                //byte[] data = Encoding.Unicode.GetBytes(_mess);
                ///// <summary>
                ///// Отправляем данные через сокет.
                ///// </summary> 
                //_socket.Send(data);



                /// <summary>
                /// Буфер для ответа.
                /// </summary> 
                byte[] answer = new byte[1024];
                StringBuilder _str = new StringBuilder();
                int bytes = 0;
                string message = null;

                ///// <summary>
                ///// Получаем ответ от сервера.
                ///// </summary>
                //do
                //{
                //    bytes = _socket.Receive(answer, answer.Length, 0);
                //    message = _str.Append(Encoding.ASCII.GetString(answer, 0, bytes)).ToString();
                //    if (message == "new")
                //    {
                //        Console.WriteLine("Статус: " + message);
                //    }
                //    if (message == "mafiaturn")
                //    {
                //        //
                //    }
                //    if (message == "medicturn")
                //    {
                //        //
                //    }
                //    if (message == "commissarturn")
                //    {
                //        //
                //    }
                //    if (message == "day")
                //    {
                //        //
                //    }
                //}
                //while (_socket.Available > 0);


                ///// <summary>
                ///// Закрываем сокет.
                ///// </summary>
                //_socket.Shutdown(SocketShutdown.Both);
                //_socket.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}