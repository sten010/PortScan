using Microsoft.AspNetCore.Mvc;
using ServerScanPort.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace ServerScanPort.Operation
{
    public class Nmap
    {
        public string TakePorts(string IpAdress)
        {
            string? NmapRead = RunCommand(IpAdress);
            if (string.IsNullOrEmpty(NmapRead))
            {
                return "Нет открытых портов.";
            }
            List<string> portArray = GetActivePorts(NmapRead);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var port in portArray)
            {
                stringBuilder.Append(port + "\n");
            }

            return stringBuilder.ToString();
        }
        private List<string> GetActivePorts(string NmapRead)
        {
            List<string> activePort = new();
            IEnumerable<string> splitNmap = NmapRead.Split('\n');

            foreach (string nmap in splitNmap)
            {
                if (!StartsWithNumber(nmap)) continue;
                activePort.Add(nmap);
            }
            return activePort;
        }
        public static bool StartsWithNumber(string input)
        {
            // Регулярное выражение для проверки, начинается ли строка с цифры
            string pattern = @"^\d";
            Regex regex = new Regex(pattern);

            // Проверка, соответствует ли начало строки регулярному выражению
            return regex.IsMatch(input);
        }
        static string? RunCommand(string ipAdress)
        {
            string nmapPath = @"C:\Program Files (x86)\Nmap\nmap.exe";

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-Command \"cd C:\\; & '{nmapPath}' -T4 {ipAdress}\"",
                UseShellExecute = false, // Для перенаправления вывода
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
                Verb = "runas"
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                try
                {
                    process.Start();

                    // Чтение вывода и ошибок
                    string output = process.StandardOutput.ReadToEnd();
                    string error = process.StandardError.ReadToEnd();

                    process.WaitForExit();

                    // Выводим результат
                    if (process.ExitCode != 0)
                    {
                        return null;
                    }
                    else
                    {
                        return output;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
