using Microsoft.AspNetCore.Mvc;
using ServerScanPort.Data;
using System.Diagnostics;

namespace ServerScanPort.Operation
{
    public class Nmap
    {
        public string TakePorts(string IpAdress)
        {
            List<PortScan> PortScan = new(); 
            if (string.IsNullOrWhiteSpace(IpAdress))
            {
                return null;
            }
            string findPort = StartScan(IpAdress);
            if (string.IsNullOrEmpty(findPort))
            {
                return "Нет открытых портов.";
            }
            return findPort;
        }
        private string? StartScan(string IpAdress)
        {
            try
            {
                // Запускаем команду nmap
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "nmap",
                        Arguments = $"-T4 -F {IpAdress}",
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        CreateNoWindow = true
                    }
                };

                process.Start();
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (process.ExitCode == 0)
                {
                    return null;
                }
                return process.StandardOutput.ReadToEnd();
            }
            catch(Exception ex)
            {
                
            }
            return null;
        }
    }
}
