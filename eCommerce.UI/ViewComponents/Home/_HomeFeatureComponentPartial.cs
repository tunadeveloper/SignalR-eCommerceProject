using eCommerce.UI.DTOs.PromotionDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.UI.ViewComponents.Home
{
    public class _HomeFeatureComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _HomeFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var result = await client.GetAsync("https://localhost:7224/api/Promotions");
            if (result.IsSuccessStatusCode)
            {
                var jsonData = await result.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPromotionDTO>>(jsonData);
                return View(values);
            }
            return View(null);
        }
    }
}
