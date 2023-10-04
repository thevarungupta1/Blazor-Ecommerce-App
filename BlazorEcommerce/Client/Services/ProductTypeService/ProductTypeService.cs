using BlazorEcommerce.Shared;
using System.Net.Http.Json;

namespace BlazorEcommerce.Client.Services.ProductTypeService
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly HttpClient _http;
        public List<ProductType> ProductTypes { get; set; } = new List<ProductType>();

        public ProductTypeService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetProductTypes()
        {
            var result = await _http
                .GetFromJsonAsync<ServiceResponse<List<ProductType>>>("api/producttype");
            ProductTypes = result.Data;
        }
    }
}
