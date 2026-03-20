using eCommerce.DTO.DTOs.OrderDTOs;
using eCommerce.DTO.DTOs.PaymentTransactionDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentTransactionController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PaymentTransactionController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/PaymentTransactions");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPaymentTransactionDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> InsertPaymentTransaction()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7224/api/Orders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<ResultOrderDTO>>(jsonData);
            ViewBag.Orders = orders;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertPaymentTransaction(CreatePaymentTransactionDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/PaymentTransactions", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ödeme Başarıyla Eklendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Ödeme Eklenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> UpdatePaymentTransaction(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7224/api/PaymentTransactions/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Ödeme Verisi Bulunamıyor";
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var payment = JsonConvert.DeserializeObject<ResultPaymentTransactionDTO>(jsonData);

            var ordersResponse = await client.GetAsync("https://localhost:7224/api/Orders");
            var ordersJson = await ordersResponse.Content.ReadAsStringAsync();
            var orders = JsonConvert.DeserializeObject<List<ResultOrderDTO>>(ordersJson);
            ViewBag.Orders = orders;

            return View(payment);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePaymentTransaction(UpdatePaymentTransactionDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/PaymentTransactions", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ödeme Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Ödeme Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeletePaymentTransaction(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/PaymentTransactions?id={id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Ödeme Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Ödeme Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}

