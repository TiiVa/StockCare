using System.Net.Http.Json;
using StockCare.Client.ServiceInterfaces;
using StockCare.DTOs.DTOs.Product;
using StockCare.SharedInterfaces;
namespace StockCare.Client.Services;

public class ProductService : IProductService
{
	private readonly HttpClient _httpClient;

	public ProductService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
		var response = await _httpClient.GetAsync("/products");

		if (!response.IsSuccessStatusCode)
		{
			return Enumerable.Empty<ProductDto>();
		}

		var result = await response.Content.ReadFromJsonAsync<List<ProductDto>>();
		return result ?? Enumerable.Empty<ProductDto>();
	}

	public async Task<ProductDto> GetByIdAsync(int id)
	{
		var response = await _httpClient.GetAsync($"/products/{id}");

		if (!response.IsSuccessStatusCode)
		{
			return new ProductDto();
		}

		var result = await response.Content.ReadFromJsonAsync<ProductDto>();
		return result ?? new ProductDto();
	}

	public async Task AddAsync(ProductDto entity)
	{
		var response = await _httpClient.PostAsJsonAsync("/products", entity);

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task UpdateAsync(ProductDto entity, int id)
	{
		var response = await _httpClient.PutAsJsonAsync($"/products/{id}", entity);

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}

	public async Task DeleteAsync(int id)
	{
		var response = await _httpClient.DeleteAsync($"/products/{id}");

		if (!response.IsSuccessStatusCode)
		{
			return;
		}
	}
}