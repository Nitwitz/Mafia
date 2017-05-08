using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public struct LEvent
    {
        /// <summary>
        /// Дата и время события.
        /// </summary>      
        public DateTime dateTime;
        /// <summary>
        /// Тип события.
        /// </summary>
        public LogEventType type;
        ///Источник ...
        public String source;
        /// <summary>
        /// Сообщение о произошедшем событии.
        /// </summary>
        public String message;
        /// <summary>
        /// Дополнительная информация о произошедшем событии.
        /// </summary>
        public String[] args;
        /// <summary>
        /// Метод приводящий запись о событии в нужный для журнала вид.
        /// </summary>
        /// <returns>Запись о событии в заданном формате.</returns>
        public string ToString()
        {
            return string.Format("{0} | {1} --- {2} : {3}", dateTime, type, source, message);
        }
    
    }
}
