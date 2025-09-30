using FastEndpoints;
using StockCare.DataAccess.RepositoryInterfaces;

namespace StockCare.Api.Endpoints.Product.GetById
{
	public class Handler(IProductRepository repo) : Endpoint<Request, Response>
	{

		public override void Configure()
		{
			Get("/products/{id}");
			AllowAnonymous();
		}

		public override async Task HandleAsync(Request req, CancellationToken ct)
		{
			var product = await repo.GetByIdAsync(req.Id);

			await Send.OkAsync(new Response()
			{
				Product = product,
			}, cancellation: ct);
		}
	}
}
