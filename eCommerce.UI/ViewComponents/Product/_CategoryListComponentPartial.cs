using eCommerce.UI.DTOs.CategoryDTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerce.UI.ViewComponents.Product
{
    public class _CategoryListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CategoryListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7224/api/Categories");
            var values = response.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<ResultCategoryDTO>>(await response.Content.ReadAsStringAsync())
                : new List<ResultCategoryDTO>();

            return View(values);
        }
    }
}
