using eCommerce.DTO.DTOs.CategoryDTOs;
using eCommerce.DTO.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Products");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InsertProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Categories");

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(json);

            ViewBag.Categories = categories;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(CreateProductDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ürün Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Ürün Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Products/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Ürün Verisi Bulunamıyor";
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var product = JsonConvert.DeserializeObject<ResultProductDTO>(jsonData);

            var categoryResponse = await client.GetAsync("https://localhost:7224/api/Categories");
            var categoryJson = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(categoryJson);

            ViewBag.Categories = categories;

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Products", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ürün Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Ürün Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Products?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ürün Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }
            TempData["Error"] = "Ürün Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
