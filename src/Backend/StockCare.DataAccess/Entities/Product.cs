using StockCare.DTOs.Enums;

namespace StockCare.DataAccess.Entities;

public class Product
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public Unit Unit { get; set; }
	public int PackageSize { get; set; }
	public bool IsOutOfStock { get; set; }
	public ICollection<ProductStock>? ProductStocks { get; set; }
	

}