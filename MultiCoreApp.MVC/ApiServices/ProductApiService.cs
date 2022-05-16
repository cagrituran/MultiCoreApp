using System.Text;
using MultiCoreApp.MVC.DTOs;
using Newtonsoft.Json;

namespace MultiCoreApp.MVC.ApiServices
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;
        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<ProductsWithCategoryDto>> GetAllAsync()
        {
            IEnumerable<ProductsWithCategoryDto> ProductsWithCategoryDtos;
            var response = await _httpClient.GetAsync("product"); // api - controllerda verdigim isim neyse o

            if (response.IsSuccessStatusCode)
            {
                ProductsWithCategoryDtos = JsonConvert.DeserializeObject<IEnumerable<ProductsWithCategoryDto>>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                ProductsWithCategoryDtos = null;
            }
            return ProductsWithCategoryDtos;

        }
        public async Task<ProductsWithCategoryDto> GetByIdAsync(Guid id)
        {
            var response = await _httpClient.GetAsync($"product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductsWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
            }
            else
            {
                return null!;
            }

        }
        public async Task<ProductsWithCategoryDto> AddAsync(ProductsWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                proDto = JsonConvert.DeserializeObject<ProductsWithCategoryDto>(await response.Content.ReadAsStringAsync())!;
                return proDto;

            }
            else
            {
                return null!;
            }
        }
        public async Task<bool> Update(ProductsWithCategoryDto proDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(proDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"product", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public async Task<IEnumerable<ProductsWithCategoryDto>> GetAllWithCategoryAsync()
        {
            IEnumerable<ProductsWithCategoryDto> ProductsWithCategoryDtos;
            var response = await _httpClient.GetAsync("product/categoryall"); // api - controllerda verdigim isim neyse o

            if (response.IsSuccessStatusCode)
            {
                ProductsWithCategoryDtos = JsonConvert.DeserializeObject<IEnumerable<ProductsWithCategoryDto>>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                ProductsWithCategoryDtos = null;
            }
            return ProductsWithCategoryDtos;

        }
        public async Task<ProductsWithCategoryDto> GetByIdForDetailsAsync(Guid id)
        {

            var response = await _httpClient.GetAsync($"product/{id}/category"); // api - controllerda verdigim isim neyse o

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ProductsWithCategoryDto>(await response.Content.ReadAsStringAsync())!;

            }
            else
            {
                return null!;
            }


        }
    }
}
