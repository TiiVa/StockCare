using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using StockCare.DataAccess.RepositoryInterfaces;
using StockCare.DTOs.DTOs.Product;
using StockCare.DataAccess.Converters.Product;

namespace StockCare.DataAccess.Repositories;

public class ProductRepository(StockCareDbContext context) : IProductRepository
{
	public async Task<IEnumerable<ProductDto>> GetAllAsync()
	{
		var products = await context.Products
			.ToListAsync();

		return products.Select(x => x.ConvertToDto());
	}

	public async Task<ProductDto> GetByIdAsync(int id)
	{
		var product = await context.Products
			.FirstOrDefaultAsync(p => p.Id == id);

		if (product is null)
		{
			return new ProductDto();
		}

		return product.ConvertToDto();
	}

	public async Task AddAsync(ProductDto entity)
	{

		entity.LastUpdated = DateTime.UtcNow;
		await context.Products.AddAsync(entity.ConvertToModel());

		await context.SaveChangesAsync();
	}

	public async Task UpdateAsync(ProductDto entity, int id)
	{
		var productToUpdate = await context.Products.FindAsync(id);

		productToUpdate.Quantity = entity.Quantity;
		productToUpdate.MinStockLevel = entity.MinStockLevel;
		productToUpdate.LastUpdated = DateTime.UtcNow;
		productToUpdate.Name = entity.Name;
		productToUpdate.PackageSize = entity.PackageSize;
		productToUpdate.Unit = entity.Unit;

		await context.SaveChangesAsync();
	}

	public async Task DeleteAsync(int id)
	{
		var productToRemove = await context.Products.FindAsync(id);

		if (productToRemove is null)
		{
			return;
		}

		context.Products.Remove(productToRemove);

		await context.SaveChangesAsync();

	}
}