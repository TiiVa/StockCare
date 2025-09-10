using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using StockCare.DataAccess;

namespace StockCare.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<StockCareDbContext>(options =>
            {
	            options.UseSqlite(builder.Configuration.GetConnectionString(connectionString));
            });

            //builder.Services.AddFastEndpoints();

            builder.Services.AddDataAccess();

			var app = builder.Build();

			//app.UseFastEndpoints();

			app.Run();
        }
    }
}
