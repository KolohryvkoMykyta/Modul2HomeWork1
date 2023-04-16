using Modul2HomeWork1.Enums;
using Modul2HomeWork1.Exceptions;

namespace Modul2HomeWork1
{
    public static class Starter
    {
        private static readonly Logger Logger = Logger.Instance;

        public static void Run()
        {
            var random = new Random();

            for (int i = 0; i < 100; i++)
            {
                int methodNumber = random.Next(3);
                bool result;

                try
                {
                    switch (methodNumber)
                    {
                        case 0:
                            result = Actions.First();
                            break;
                        case 1:
                            result = Actions.Second();
                            break;
                        default:
                            result = Actions.Third();
                            break;
                    }
                }
                catch (BusinessException exception)
                {
                    Logger.Log(LogType.Warning, $"Action got thid custom Exception: {exception.Message}");
                }
                catch (Exception exception)
                {
                    Logger.Log(LogType.Error, $"Action failed by reason: {exception.Message}");
                }
            }

            Logger.WriteLogsToFile();
        }
    }
}
