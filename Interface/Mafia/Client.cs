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
    }
}