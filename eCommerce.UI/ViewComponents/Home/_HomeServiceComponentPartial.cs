using eCommerce.UI.DTOs.ServiceDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeServiceComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeServiceComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Services");
            var values = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<ResultServiceDTO>>(await response.Content.ReadAsStringAsync())
                : new List<ResultServiceDTO>();

            return View(values);
        }
    }
}
