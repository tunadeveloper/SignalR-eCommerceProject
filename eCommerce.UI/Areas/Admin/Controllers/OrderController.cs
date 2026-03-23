using eCommerce.DTO.DTOs.OrderDetailDTOs;
using eCommerce.DTO.DTOs.OrderDTOs;
using eCommerce.DTO.DTOs.PaymentTransactionDTOs;
using eCommerce.DTO.DTOs.ProductDTOs;
using eCommerce.DTO.DTOs.ShippingCompanyDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace eCommerce.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public OrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var ordersResponse = await client.GetAsync("https://localhost:7224/api/Orders");
            List<ResultOrderDTO> orders = new();
            if (ordersResponse.IsSuccessStatusCode)
            {
                var json = await ordersResponse.Content.ReadAsStringAsync();
                orders = JsonConvert.DeserializeObject<List<ResultOrderDTO>>(json);
            }

            var detailsResponse = await client.GetAsync("https://localhost:7224/api/OrderDetails");
            List<ResultOrderDetailDTO> orderDetails = new();
            if (detailsResponse.IsSuccessStatusCode)
            {
                var json = await detailsResponse.Content.ReadAsStringAsync();
                orderDetails = JsonConvert.DeserializeObject<List<ResultOrderDetailDTO>>(json);
            }

            var paymentsResponse = await client.GetAsync("https://localhost:7224/api/PaymentTransactions");
            List<ResultPaymentTransactionDTO> payments = new();
            if (paymentsResponse.IsSuccessStatusCode)
            {
                var json = await paymentsResponse.Content.ReadAsStringAsync();
                payments = JsonConvert.DeserializeObject<List<ResultPaymentTransactionDTO>>(json);
            }

            ViewBag.OrderDetails = orderDetails;
            ViewBag.Payments = payments;

            return View(orders);
        }

        public async Task<IActionResult> InsertOrder()
        {
            var client = _httpClientFactory.CreateClient();

            var shippingResponse = await client.GetAsync("https://localhost:7224/api/ShippingCompanies");
            var shippingJson = await shippingResponse.Content.ReadAsStringAsync();
            var shippingCompanies = JsonConvert.DeserializeObject<List<ResultShippingCompanyDTO>>(shippingJson);
            ViewBag.ShippingCompanies = shippingCompanies;

            var productsResponse = await client.GetAsync("https://localhost:7224/api/Products");
            var productsJson = await productsResponse.Content.ReadAsStringAsync();
            var products = JsonConvert.DeserializeObject<List<ResultProductDTO>>(productsJson);
            ViewBag.Products = products;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrder(CreateOrderDTO dto, List<CreateOrderDetailDTO> orderDetails)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7224/api/Orders", content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Sipariş Eklenirken Bir Sorun Oluştu";
                return RedirectToAction(nameof(InsertOrder));
            }

            var responseJson = await responseMessage.Content.ReadAsStringAsync();
            ResultOrderDTO? createdOrder = null;
            foreach (var detail in orderDetails)
            {
                detail.OrderId = int.Parse(createdOrder.Id);
                var detailJson = JsonConvert.SerializeObject(detail);
                StringContent detailContent = new StringContent(detailJson, Encoding.UTF8, "application/json");
                await client.PostAsync("https://localhost:7224/api/OrderDetails", detailContent);
            }

            TempData["Success"] = "Sipariş Başarıyla Eklendi";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> UpdateOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync($"https://localhost:7224/api/Orders/{id}");
            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Sipariş Verisi Bulunamıyor";
                return View();
            }

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var order = JsonConvert.DeserializeObject<ResultOrderDTO>(jsonData);

            var shippingResponse = await client.GetAsync("https://localhost:7224/api/ShippingCompanies");
            var shippingJson = await shippingResponse.Content.ReadAsStringAsync();
            var shippingCompanies = JsonConvert.DeserializeObject<List<ResultShippingCompanyDTO>>(shippingJson);

            ViewBag.ShippingCompanies = shippingCompanies;
            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOrder(UpdateOrderDTO dto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(dto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7224/api/Orders", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Sipariş Başarıyla Güncellendi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Sipariş Güncellenirken Bir Sorun Oluştu";
            return View();
        }

        public async Task<IActionResult> DeleteOrder(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7224/api/Orders?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["Success"] = "Sipariş Başarıyla Silindi";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "Sipariş Silinirken Bir Sorun Oluştu";
            return View();
        }
    }
}
