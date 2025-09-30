using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCare.DataAccess.RepositoryInterfaces;

namespace StockCare.Api.Endpoints.Product.Update
{
	public class Handler(IProductRepository repo) : Endpoint<Request, Results<Ok, BadRequest>>
	{
		public override void Configure()
		{
			Put("/products/{id}");
			AllowAnonymous();
		}

		public override async Task<Results<Ok, BadRequest>> ExecuteAsync(Request req, CancellationToken ct)
		{
			var productToUpdate = await repo.GetByIdAsync(req.Id);

			if(productToUpdate is null)
			{
				return TypedResults.BadRequest();
			}

			productToUpdate.MinStockLevel = req.MinStockLevel;
			productToUpdate.LastUpdated = req.LastUpdated;
			productToUpdate.Name = req.Name;
			productToUpdate.Unit = req.Unit;
			productToUpdate.Quantity = req.Quantity;
			productToUpdate.PackageSize = req.PackageSize;

			await repo.UpdateAsync(productToUpdate, req.Id);

			return TypedResults.Ok();
		}
	}
}
