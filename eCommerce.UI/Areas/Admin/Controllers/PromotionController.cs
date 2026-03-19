using eCommerce.DTO.DTOs.PromotionDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PromotionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Promotions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPromotionDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertPromotion() => View();

        [HttpPost]
        public async Task<IActionResult> InsertPromotion(CreatePromotionDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Promotions", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kampanya Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Kampanya Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdatePromotion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Promotions/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPromotionDTO>(jsonData);
                return View(values);
            }
            TempData["Error"] = "Kampanya Verisi Bulunamıyor";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(UpdatePromotionDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Promotions", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kampanya Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Kampanya Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeletePromotion(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Promotions?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kampanya Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Kampanya Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
