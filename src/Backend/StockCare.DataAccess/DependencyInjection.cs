using Microsoft.Extensions.DependencyInjection;

namespace StockCare.DataAccess;

public static class DependencyInjection
{
	public static IServiceCollection AddDataAccess(this IServiceCollection services)
	{
		return services; // TODO: Lägg in repositories
	}
}