using Microsoft.EntityFrameworkCore;
using StockCare.DataAccess.Entities;

namespace StockCare.DataAccess;

public class StockCareDbContext : DbContext
{
	public DbSet<Product> Products { get; set; }
	public DbSet<Stock> Stocks { get; set; }
	public DbSet<ProductStock> ProductStocks { get; set; }

	public StockCareDbContext(DbContextOptions<StockCareDbContext> options) : base(options)
	{
		
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<ProductStock>()
			.HasKey(ps => new { ps.ProductId, ps.StockId });


	}
}