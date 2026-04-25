using eCommerce.UI.DTOs.ContactDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Contacts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertContact() => View();

        [HttpPost]
        public async Task<IActionResult> InsertContact(CreateContactDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Contacts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İletişim Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "İletişim Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Contacts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDTO>(jsonData);
                return View(values);
            }
            TempData["Error"] = "İletişim Verisi Bulunamıyor";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Contacts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İletişim Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "İletişim Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Contacts?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "İletişim Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "İletişim Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
