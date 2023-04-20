using System.Globalization;
using System.Text;
using Modul2HomeWork1.Models;
using Newtonsoft.Json;

namespace Modul2HomeWork1
{
    public static class FileService
    {
        private const string FileNameFormat = "hh.mm.ss dd.MM.yyyy";
        private static string _directoryName;

        static FileService()
        {
            var configFile = File.ReadAllText("appsettings.json");
            _directoryName = JsonConvert.DeserializeObject<ConfigurationModel>(configFile) !.DirectoryPath;
        }

        public static void WriteFile(string content)
        {
            var directory = Directory.CreateDirectory(_directoryName);
            var files = directory.GetFiles();

            if (files.Count() > 2)
            {
                var dates = new DateTime[files.Length];

                for (int i = 0; i < files.Length; i++)
                {
                    var fileName = files[i].Name[..^4];
                    dates[i] = DateTime.ParseExact(fileName, FileNameFormat, CultureInfo.InvariantCulture);
                }

                var minimumIndex = 0;
                var minimumValue = DateTime.MaxValue;

                for (int i = 0; i < files.Length; i++)
                {
                    if (dates[i] < minimumValue)
                    {
                        minimumIndex = i;
                        minimumValue = dates[i];
                    }
                }

                files[minimumIndex].Delete();
            }

            var path = $"{_directoryName}/{DateTime.UtcNow.ToString(FileNameFormat)}.txt";
            using (var file = new FileStream(path, FileMode.CreateNew))
            {
                var buffer = Encoding.UTF8.GetBytes(content);
                file.Write(buffer);
            }
        }
    }
}
