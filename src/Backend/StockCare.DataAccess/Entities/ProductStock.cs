namespace StockCare.DataAccess.Entities;

public class ProductStock
{
	public int ProductId { get; set; }
	public Product Product { get; set; }
	public int StockId { get; set; }
	public Stock Stock { get; set; }
	public int Quantity { get; set; }
	public int MinStockLevel { get; set; }
	public DateTime LastUpdated { get; set; }
}