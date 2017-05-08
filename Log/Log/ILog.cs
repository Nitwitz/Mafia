using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log
{
    public interface ILog
    {
        void Write(LEvent e);
        /// <summary>
        /// Получить все записи о случившиихся событиях из журнала и помеситть в массив.
        /// </summary>
        /// <returns></returns>
        List<LEvent> GetAll();
        /// <summary>
        /// Получить записи из журнала в отсортированном виде.
        /// </summary>
        /// <returns></returns>
        LEvent[] GetAllSorted();
        /// <summary>
        /// Поиск события в журнале по дате и времени.
        /// </summary>
        /// <param name="dt">Дата и время.</param>
        /// <returns></returns>
        LEvent[] Search(DateTime dt);
        /// <summary>
        /// Вносит в журнал событий запись сведений с заданным текстом сообщения.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="m"></param>
        /// <param name="messType"></param>
        void WriteEntry(string s, string m, LogEventType messType);
    }
}
