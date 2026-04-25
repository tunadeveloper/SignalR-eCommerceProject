using eCommerce.UI.DTOs.OrderDetailDTOs;
using eCommerce.UI.DTOs.OrderDTOs;
using eCommerce.UI.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/OrderDetails");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultOrderDetailDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InsertOrderDetail()
        {
            var client = _httpClientFactory.CreateClient();

            var ordersResponse = await client.GetAsync("https://localhost:7224/api/Orders");
            var ordersJson = await ordersResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<ResultOrderDTO>>(ordersJson);
            ViewBag.Orders = orders;

            var productsResponse = await client.GetAsync("https://localhost:7224/api/Products");
            var productsJson = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(productsJson);
            ViewBag.Products = products;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrderDetail(CreateOrderDetailDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/OrderDetails", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Sipariş Detayı Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Sipariş Detayı Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdateOrderDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7224/api/OrderDetails/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Sipariş Detayı Verisi Bulunamıyor";
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var orderDetail = JsonConvert.DeserializeObject<ResultOrderDetailDTO>(jsonData);

            var ordersResponse = await client.GetAsync("https://localhost:7224/api/Orders");
            var ordersJson = await ordersResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<ResultOrderDTO>>(ordersJson);
            ViewBag.Orders = orders;

            var productsResponse = await client.GetAsync("https://localhost:7224/api/Products");
            var productsJson = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(productsJson);
            ViewBag.Products = products;

            return View(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/OrderDetails", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Sipariş Detayı Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Sipariş Detayı Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/OrderDetails?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Sipariş Detayı Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Sipariş Detayı Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}

