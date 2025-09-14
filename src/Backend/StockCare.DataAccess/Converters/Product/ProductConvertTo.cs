using StockCare.DataAccess.Entities;
using StockCare.DTOs.DTOs.Product;
using StockCare.DTOs.Enums;

namespace StockCare.DataAccess.Converters.Product;

public static class ProductConvertTo
{
	public static ProductDto ConvertToDto(this Entities.Product productModel)
	{

		var productDto = new ProductDto
		{
			Id = productModel.Id,
			Name = productModel.Name,
			Unit = productModel.Unit,
			PackageSize = productModel.PackageSize,
			Quantity = productModel.Quantity,
			MinStockLevel = productModel.MinStockLevel,
			LastUpdated = productModel.LastUpdated
		};

		return productDto;
	}

	public static Entities.Product ConvertToModel(this ProductDto productDto)
	{
		var product = new Entities.Product
		{
			Id = productDto.Id,
			Name = productDto.Name,
			Unit = productDto.Unit,
			PackageSize = productDto.PackageSize,
			Quantity = productDto.Quantity,
			MinStockLevel = productDto.MinStockLevel,
			LastUpdated = productDto.LastUpdated

		};

		return product;
	}
}