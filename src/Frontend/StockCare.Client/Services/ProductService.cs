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
		throw new NotImplementedException();
	}

	public async Task AddAsync(ProductDto entity)
	{
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(ProductDto entity, int id)
	{
		throw new NotImplementedException();
	}

	public async Task DeleteAsync(int id)
	{
		throw new NotImplementedException();
	}
}