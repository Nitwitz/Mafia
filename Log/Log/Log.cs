using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Log
{
    public abstract class Log : ILog
    {
        /// <summary>
        /// Имя источника.
        /// </summary>
        protected string sourceName;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn">Имя источника.</param>
        public Log(string sn)
        {
            sourceName = sn;
        }
        /// <summary>
        /// Запись события в журнал.
        /// </summary>
        /// <param name="e">Событие.</param>
        public abstract void Write(LEvent e);

        /// <summary>
        /// Получить все записи о случившиихся событиях из журнала в массив событий.
        /// </summary>
        /// <returns>Массив событий </returns>
        public abstract List<LEvent> GetAll();
        
        /// <summary>
        /// Получить записи из журнала в отсортированном виде.
        /// </summary>
        /// <returns>Отсортированный массив событий.</returns>
        public LEvent[] GetAllSorted()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Поиск события в массиве событий по дате и времени.
        /// </summary>
        /// <param name="dt">Нужные дата и время.</param>
        /// <returns></returns>
        public LEvent[] Search(DateTime dt)
        {
            List<LEvent> _result = new List<LEvent>();
            foreach (LEvent _le in GetAll())
                if (_le.dateTime.Equals(dt))
                    _result.Add(_le);
            return _result.ToArray();
        }
        /// <summary>
        /// Вносит в журнал событий запись сведений с заданным текстом сообщения.
        /// </summary>
        /// <param name="s">Источник.</param>
        /// <param name="m">Сообщение о произошедшем событии.</param>
        /// <param name="messType">Тип произошедшего сообщения.</param>
        public void WriteEntry(string s, string m, LogEventType messType)
        {
            Write(new LEvent() { dateTime = DateTime.Now, source = s, message = m, type = messType } );
            

        }
    }
}
