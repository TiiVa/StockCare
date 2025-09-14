using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using StockCare.DataAccess;
using StockCare.DataAccess.RepositoryInterfaces;
using StockCare.DTOs.DTOs.Product;

namespace StockCare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddDbContext<StockCareDbContext>(options =>
			{
				options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
			});


			builder.Services.AddDataAccess();

			var app = builder.Build();

			app.MapGet("/products", async (IProductRepository repo) =>
			{
				var products = await repo.GetAllAsync();
				return products;
			});
			app.MapGet("/products/{id}", async (IProductRepository repo, int id) =>
			{
				var product = await repo.GetByIdAsync(id);
				return product;
			});
			app.MapPost("/products", async (IProductRepository repo, ProductDto newProduct) =>
			{
				await repo.AddAsync(newProduct);

			});
			app.MapPut("/products/{id}", async (IProductRepository repo, ProductDto productToUpdate, int id) =>
			{
				var product = await repo.GetByIdAsync(id);

				product.LastUpdated = DateTime.Now;
				product.MinStockLevel = productToUpdate.MinStockLevel;
				product.Name = productToUpdate.Name;
				product.PackageSize = productToUpdate.PackageSize;
				product.Quantity = productToUpdate.Quantity;
				product.Unit = productToUpdate.Unit;

				await repo.UpdateAsync(product, id);
			});

			app.MapDelete("/products/{id}", async (IProductRepository repo, int id) =>
			{
				await repo.DeleteAsync(id);
			});

			app.Run();
        }
    }
}
