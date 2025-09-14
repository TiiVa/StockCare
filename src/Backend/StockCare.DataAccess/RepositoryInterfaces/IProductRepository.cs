using StockCare.DTOs.DTOs.Product;
using StockCare.SharedInterfaces;

namespace StockCare.DataAccess.RepositoryInterfaces;

public interface IProductRepository : IRepository<ProductDto, int>
{
	
}