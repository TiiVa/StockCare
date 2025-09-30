using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;
using StockCare.DataAccess.RepositoryInterfaces;

namespace StockCare.Api.Endpoints.Product.Delete
{
	public class Handler(IProductRepository repo) : Endpoint<Request, Results<Ok, NotFound>>
	{
		public override void Configure()
		{
			Delete("/products/{id}");
			AllowAnonymous();
		}

		public override async Task<Results<Ok, NotFound>> ExecuteAsync(Request req, CancellationToken ct)
		{
			var product = await repo.GetByIdAsync(req.Id);

			if(product is null)
			{
				return TypedResults.NotFound();
			}

			await repo.DeleteAsync(req.Id);

			return TypedResults.Ok();

		}
	}
}
