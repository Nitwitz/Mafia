using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Log
{
    public class FileLog : Log
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fn"></param>
        public FileLog(string fn)
            : base(fn)
        {
            fs = new FileStream(sourceName, FileMode.OpenOrCreate);
        }
        /// <summary>
        /// 
        /// </summary>
        private FileStream fs;
        /// <summary>
        /// Запись события в журнал.
        /// </summary>
        /// <param name="e"></param>
        public override void Write(LEvent e)
        {
            string _temp = e.ToString() + "\n\r";
            fs.Write(Encoding.Default.GetBytes(_temp), 0, _temp.Length);
            fs.Flush();
        }

        /// <summary>
        /// Получить все союытия в массив собюытий.
        /// </summary>
        /// <returns></returns>
        public override List<LEvent> GetAll()
        {
            string[] eventLines;
            using (StreamReader reader = new StreamReader(fs))
            {
                eventLines = reader.ReadToEnd().Split(new string[] { "\n\r" }, StringSplitOptions.RemoveEmptyEntries);
            }
            DateTime _dt;
            LogEventType _type;
            string _mes, _source;

            List<LEvent> listE = new List<LEvent>();

            foreach(string _l in eventLines )
            {
                _dt = DateTime.Parse(_l.Substring(0, _l.IndexOf("|")));
                _type = (LogEventType)Enum.Parse(typeof(LogEventType), (_l.Substring(_l.IndexOf("|") + 1, _l.IndexOf("-") - _l.IndexOf("|") + 1)));
                _source = _l.Substring(_l.IndexOf("-") + 1, _l.IndexOf(":") - _l.IndexOf("-") + 1);
                _mes = _l.Substring(_l.IndexOf(":") + 1);
                listE.Add(new LEvent()
                {
                    dateTime = _dt,
                    type = _type,
                    source = _source,
                    message = _mes
                });
            }

            return listE;
        }
    }
}
