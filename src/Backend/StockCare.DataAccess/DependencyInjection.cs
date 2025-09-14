using Microsoft.Extensions.DependencyInjection;
using StockCare.DataAccess.Repositories;
using StockCare.DataAccess.RepositoryInterfaces;
namespace StockCare.DataAccess;

public static class DependencyInjection
{

	public static IServiceCollection AddDataAccess(this IServiceCollection services)
	{
		services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}

}