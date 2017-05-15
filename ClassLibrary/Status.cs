using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Стадии игры.
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Стадия подключения игроков.
        /// </summary>
        New,
        /// <summary>
        /// Ход мафии.
        /// </summary>
        MafiaTurn,
        /// <summary>
        /// Ход доткора.
        /// </summary>
        DoctorTurn,
        /// <summary>
        /// Ход комиссара.
        /// </summary>
        CommissarTurn,
        /// <summary>
        /// День, время голосования.
        /// </summary>
        Day
    }
}
