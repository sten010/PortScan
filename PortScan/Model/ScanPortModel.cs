using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServerScanPort.Data; // Можно использовать System.Text.Json или другую библиотеку для парсинга

namespace PortScan.Model
{
    public class ScanPortModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public ScanPortModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public static List<ScaningModel> ScaningModelArray { get; private set; }

        public async Task OnGetAsync()
        {
            var jsonResponse = await _httpClient.GetStringAsync("http://localhost:5043/api/Scanings");
            ScaningModelArray = JsonConvert.DeserializeObject<List<ScaningModel>>(jsonResponse);
        }
    }
}