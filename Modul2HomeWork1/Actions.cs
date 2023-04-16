using Modul2HomeWork1.Enums;
using Modul2HomeWork1.Exceptions;

namespace Modul2HomeWork1
{
    public static class Actions
    {
        private static readonly Logger Logger = Logger.Instance;

        public static bool First()
        {
            Logger.Log(LogType.Info, $"Start method: {nameof(Actions.First)}");

            return true;
        }

        public static bool Second()
        {
            throw new BusinessException("Skipped logic in method");
        }

        public static bool Third()
        {
            throw new Exception("I broke a logic");
        }
    }
}
