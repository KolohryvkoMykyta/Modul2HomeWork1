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
                Result result;

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

                if (result.Status == false)
                {
                    Logger.Log(Enums.LogType.Error, $"Action failed by a reason: {result.Message}");
                }
            }

            File.WriteAllText("log.txt", Logger.GetLogsToString());
        }
    }
}
