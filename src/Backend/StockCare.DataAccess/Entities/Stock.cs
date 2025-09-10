namespace StockCare.DataAccess.Entities;

public class Stock
{
	public int Id { get; set; }
	public ICollection<ProductStock>? StockProducts { get; set; }
}