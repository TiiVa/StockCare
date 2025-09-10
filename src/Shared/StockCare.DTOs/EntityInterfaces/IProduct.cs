using System.Runtime.InteropServices.Marshalling;
using StockCare.DTOs.Enums;

namespace StockCare.DTOs.EntityInterfaces;

public interface IProduct
{
	public int Id { get; set; }
	public string Name { get; set; }
	public Unit Unit { get; set; }
	public int PackageSize { get; set; }
	public bool IsOutOfStock { get; set; }
}