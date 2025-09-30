using FastEndpoints;
using StockCare.DataAccess.RepositoryInterfaces;

namespace StockCare.Api.Endpoints.Product.GetAll
{
	public class Handler(IProductRepository repo) : Endpoint<EmptyRequest, Response>
	{
		public override void Configure()
		{
			Get("/products");
			AllowAnonymous();
		}

		public override async Task HandleAsync(EmptyRequest req, CancellationToken ct)
		{
			var products = await repo.GetAllAsync();

			await Send.OkAsync(new Response()
			{
				Products = products
			}, cancellation: ct);
		}

	}
}
