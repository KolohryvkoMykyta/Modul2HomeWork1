using Modul2HomeWork1.Enums;

namespace Modul2HomeWork1
{
    public class Log
    {
        public Log(LogType logType, string message)
        {
            Type = logType;
            Message = message;
        }

        public DateTime Timestamp { get; private set; } = DateTime.UtcNow;

        public LogType Type { get; private set; }

        public string Message { get; private set; }
    }
}
