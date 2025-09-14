using System.Runtime.InteropServices.Marshalling;
using StockCare.DTOs.Enums;

namespace StockCare.DTOs.EntityInterfaces;

public interface IProduct
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Unit Unit { get; set; }
	public int PackageSize { get; set; }
	public int Quantity { get; set; }
	public int MinStockLevel { get; set; }
}