using Modul2HomeWork1.Enums;

namespace Modul2HomeWork1
{
    public static class Actions
    {
        private static readonly Logger Logger = Logger.Instance;

        public static Result First()
        {
            Result result = new Result(true, "Start method");
            Logger.Log(LogType.Info, $"{result.Message}: {nameof(Actions.First)}");

            return result;
        }

        public static Result Second()
        {
            Result result = new Result(true, "Skipped logic in method");
            Logger.Log(LogType.Warning, $"{result.Message}: {nameof(Actions.Second)}");

            return result;
        }

        public static Result Third()
        {
            Result result = new Result(false, "I broke a logic");
            Logger.Log(LogType.Error, $"{result.Message}: {nameof(Actions.Third)}");

            return result;
        }
    }
}
