using System.Text;
using Modul2HomeWork1.Enums;

namespace Modul2HomeWork1
{
    public class Logger
    {
        private const string LogFormat = "{0}: {1}: {2}";

        private Node _data;

        public static Logger Instance { get; } = new Logger();

        public void Log(Log log)
        {
            Console.WriteLine(string.Format(LogFormat, log.Timestamp, log.Type, log.Message));

            if (_data == null)
            {
                _data = new Node() { Log = log };
            }
            else
            {
                var temp = _data;
                _data = new Node() { Log = log, Next = temp };
            }
        }

        public void Log(LogType logType, string message)
        {
            Log(new Log(logType, message));
        }

        public string GetLogsToString()
        {
            var builder = new StringBuilder();
            var current = _data;

            while (current != null)
            {
                builder.AppendLine(string.Format(LogFormat, current.Log.Timestamp, current.Log.Type, current.Log.Message));
                current = current.Next;
            }

            return builder.ToString();
        }

        public string ConvertLogToString(Log log)
        {
            return string.Format(LogFormat, log.Timestamp, log.Type, log.Message);
        }
    }
}
