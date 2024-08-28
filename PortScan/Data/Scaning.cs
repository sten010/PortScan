namespace ServerScanPort.Data
{
    public class ScaningModel
    {
        public int Id { get; set; }
        public string? IpAdress { get; set; }  
        public DateTime DateScan { get; set; } 
        public string? Port { get; set; } 
    }
}