using eCommerce.UI.DTOs.MessageDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MessageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Messages");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertMessage() => View();

        [HttpPost]
        public async Task<IActionResult> InsertMessage(CreateMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Mesaj Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Mesaj Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Messages/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultMessageDTO>(jsonData);
                return View(values);
            }
            TempData["Error"] = "Mesaj Verisi Bulunamıyor";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Messages", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Mesaj Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Mesaj Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteMessage(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Messages?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Mesaj Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Mesaj Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
