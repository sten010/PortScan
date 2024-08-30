using PortScan.Data;

namespace ServerScanPort.Data
{
    public class ScaningModel
    {
        public int Id { get; set; }
        public string? IpAdress { get; set; }
        public DateTime DateScan { get; set; }
        public string? Port { get; set; }

        public IEnumerable<DitailsPort> DitailsPorts()
        {
            //Обработка неправильного значения
            if (string.IsNullOrEmpty(Port) || Port.Contains("Нет"))
            {
                DitailsPort[] ditails = new DitailsPort[] { new DitailsPort { NumberPort = "Нет активных портов.", TypePort = "" } };
                return ditails;
            }

            List<DitailsPort> ditailsPorts = new();

            IEnumerable<string> splitPort = Port.Split('\n');
            foreach (var port in splitPort)
            {
                //Получения номера порта
                int findPortNumber = GetPortNumber(port);
                if (findPortNumber.Equals(0)) continue;

                //Добавления нормализованного номера
                DitailsPort findPort = FindPort(port);
                if (findPort == null) continue;
                ditailsPorts.Add(findPort);
            }
            return ditailsPorts;
        }

        public IEnumerable<string> GetDitailsOnPort()
        {
            if (string.IsNullOrEmpty(Port)) return new string[] { "Нет активных портов" };
            if (Port.Contains("Нет")) return new string[] { Port };

            return Port.Split('\n');
        }
        public int GetCountPort()
        {
            if (string.IsNullOrEmpty(Port) || Port.Contains("Нет")) return 0;
            IEnumerable<string> splitPort = Port.Split('\n');
            int portCount = 0;
            foreach (var port in splitPort)
            {
                //Получения номера порта
                int findPortNumber = GetPortNumber(port);
                if (findPortNumber.Equals(0)) continue;
                //Добавления нормализованного номера
                portCount++;
            }
            return portCount;
        }
        private static int GetPortNumber(string port)
        {
            int value = 0;
            int.TryParse(string.Join("", port.Where(c => char.IsDigit(c))), out value);
            return value;
        }
        private DitailsPort? FindPort(string port)
        {
            // Удаляем лишние пробелы и разбиваем строку по пробелам
            string[] parts = port.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            return new DitailsPort()
            {
                NumberPort = parts[0].Trim(),
                TypePort = string.Join(' ', parts, 2, parts.Length - 2)
            };
        }
    }
}