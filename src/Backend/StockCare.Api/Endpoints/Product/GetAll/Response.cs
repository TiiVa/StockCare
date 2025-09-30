using StockCare.DTOs.DTOs.Product;

namespace StockCare.Api.Endpoints.Product.GetAll
{
	public class Response
	{
		public IEnumerable<ProductDto> Products { get; set; }
	}
}
