using StockCare.DTOs.DTOs.Product;
using StockCare.SharedInterfaces;

namespace StockCare.Client.ServiceInterfaces;

public interface IProductService : IService<ProductDto, int>
{
	
}