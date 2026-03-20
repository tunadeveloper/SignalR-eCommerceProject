using eCommerce.DTO.DTOs.ShippingCompanyDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippingCompanyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShippingCompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/ShippingCompanies");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultShippingCompanyDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public IActionResult InsertShippingCompany() => View();

        [HttpPost]
        public async Task<IActionResult> InsertShippingCompany(CreateShippingCompanyDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/ShippingCompanies", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kargo Firması Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Kargo Firması Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateShippingCompany(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/ShippingCompanies/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Kargo Firması Verisi Bulunamıyor";
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<ResultShippingCompanyDTO>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateShippingCompany(UpdateShippingCompanyDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/ShippingCompanies", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kargo Firması Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Kargo Firması Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteShippingCompany(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/ShippingCompanies?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Kargo Firması Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Kargo Firması Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}

