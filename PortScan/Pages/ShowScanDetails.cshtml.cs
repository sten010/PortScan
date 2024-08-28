using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServerScanPort.Data;
using System.Net.Http;

namespace PortScan.Pages
{
    public class ShowScanDetailsModel : PageModel
    {
        private readonly HttpClient _httpClient;
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public static ScaningModel ScaningModelArray { get; private set; }
        private readonly ILogger<PrivacyModel> _logger;

        public ShowScanDetailsModel(ILogger<PrivacyModel> logger , HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task OnGetAsync()
        {
            var jsonResponse = await _httpClient.GetStringAsync("http://localhost:5043/api/Scanings/" + Id.ToString());
            ScaningModelArray = JsonConvert.DeserializeObject<ScaningModel>(jsonResponse);
        }
    }
}
