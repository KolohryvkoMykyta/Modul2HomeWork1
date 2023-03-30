using Modul2HomeWork1.Enums;

namespace Modul2HomeWork1
{
    public class Logger
    {
        private const string LogFormat = "{0}: {1}: {2}";

        public static Logger Instance { get; } = new Logger();

        private List<string> Logs { get; } = new List<string>();

        public void Log(Log log)
        {
            var textLog = string.Format(LogFormat, log.Timestamp, log.Type, log.Message);

            Console.WriteLine(textLog);
            Logs.Add(textLog);
        }

        public void Log(LogType logType, string message)
        {
            Log(new Log(logType, message));
        }

        public string GetLogs()
        {
            string result = string.Empty;

            foreach (string log in Logs)
            {
                result += $"{log}\n";
            }

            return result;
        }
    }
}
