using StockCare.Client.ServiceInterfaces;
using StockCare.Client.Services;

namespace StockCare.Client;

public static class DependencyInjection
{
	public static IServiceCollection AddServices(this IServiceCollection services)
	{
		services.AddScoped<IProductService, ProductService>();

		return services;
	}
}