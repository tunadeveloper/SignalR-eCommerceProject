using Microsoft.AspNetCore.Mvc;
using eCommerce.UI.DTOs.ProductDTOs;
using Newtonsoft.Json;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomePopularProductComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomePopularProductComponentPartial(IHttpClientFactory httpClientFactory)
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
