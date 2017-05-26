using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Net.Sockets;


namespace ConsoleServer
{
    public class SClient
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
        /// <summary>
        /// 
        /// </summary>
        public TcpClient tcpClient
        {
            get;
            set;
        }
        /// <summary>
        /// 
        /// </summary>
        public Socket Client
        {
            get { return tcpClient.Client; }

        }
    }
}
