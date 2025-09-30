using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCare.DataAccess.RepositoryInterfaces;
using StockCare.DTOs.DTOs.Product;

namespace StockCare.Api.Endpoints.Product.Add
{
	public class Handler(IProductRepository repo) : Endpoint<Request, Results<Ok, BadRequest>>
	{
		public override void Configure()
		{
			Post("/products");
			AllowAnonymous();
		}

		public override async Task<Results<Ok, BadRequest>> HandleAsync(Request req, CancellationToken ct)
		{
			var allProducts = await repo.GetAllAsync();

			if (allProducts.Any(p => p.Name == req.Name))
			{
				return TypedResults.BadRequest();
			}

			var productToAdd = new ProductDto()
			{
				
				 Name = req.Name,
				 Unit = req.Unit,
				 LastUpdated = DateTime.UtcNow,
				 Quantity = req.Quantity,
				 MinStockLevel = req.MinStockLevel,
				 PackageSize = req.PackageSize

			};

			await repo.AddAsync(productToAdd);

			return TypedResults.Ok();
		}
	}
}
