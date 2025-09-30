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

			builder.Services.AddFastEndpoints();


			builder.Services.AddDbContext<StockCareDbContext>(options =>
			{
				options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
			});


			builder.Services.AddDataAccess();

			var app = builder.Build();

			app.UseFastEndpoints();

			app.Run();
        }
    }
}
