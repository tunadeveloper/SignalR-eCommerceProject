using eCommerce.UI.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ServiceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertService() => View();

        [HttpPost]
        public async Task<IActionResult> InsertService(CreateServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Services", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Hizmet Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Hizmet Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Services/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultServiceDTO>(jsonData);
                return View(values);
            }
            TempData["Error"] = "Hizmet Verisi Bulunamıyor";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateService(UpdateServiceDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Services", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Hizmet Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Hizmet Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteService(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Services?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Hizmet Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Hizmet Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
