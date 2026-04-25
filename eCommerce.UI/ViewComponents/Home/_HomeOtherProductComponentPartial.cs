using eCommerce.UI.DTOs.ProductDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeOtherProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeOtherProductComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Products");
            var values = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<ResultProductDTO>>(await response.Content.ReadAsStringAsync())
                : new List<ResultProductDTO>();

            return View(values);
        }
    }
}
