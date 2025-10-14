using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using StockCare.Client.ServiceInterfaces;
using StockCare.DTOs.DTOs.Product;
using System.Text.Json.Serialization;

namespace StockCare.Client.Components.Pages;

public partial class Products : ComponentBase
{
	[Inject] private IProductService ProductService { get; set; }
	[Inject] private NavigationManager NavigationManager { get; set; }
	private List<ProductDto> ProductDtoList { get; set; } = [];
	private ProductDto ProductToUpdate { get; set; } = new();
	private readonly PaginationState _paginationState = new PaginationState { ItemsPerPage = 5 };
	private bool ShowUpdateProductForm { get; set; }
	private bool ShowAllProducts { get; set; }
	private bool ShowWithdrawalForm { get; set; }
	private int WithdrawalQuantity { get; set; }
	private bool TooLowStockLevel { get; set; }
	[Parameter] public int ProductId { get; set; }


	protected override async Task OnInitializedAsync()
	{
		ProductDtoList.AddRange(await ProductService.GetAllAsync());

		await base.OnInitializedAsync();

		ShowAllProducts = true;
	}

	private void OnPageSizeChanged(ChangeEventArgs e)
	{
		if (e.Value is not null)
		{
			_paginationState.ItemsPerPage = int.Parse((string)e.Value);
		}
	}

	private async Task ShowAddNewProductView()
	{
		NavigationManager.NavigateTo("/newProduct");
	}

	private async Task ShowUpdateDetailsView(ProductDto product)
	{
		
		ProductId = product.Id;

		NavigationManager.NavigateTo($"/updateProduct/{ProductId}");
	}

	private async Task OnDelete(ProductDto product)
	{
		await ProductService.DeleteAsync(product.Id);
		ProductDtoList.Clear();
		ProductDtoList.AddRange(await ProductService.GetAllAsync());
	}

	private async Task UpdateProduct(int id)
	{
		ProductToUpdate.Id = id;
		await ProductService.UpdateAsync(ProductToUpdate, ProductToUpdate.Id);

		ProductDtoList.Clear();
		ProductDtoList.AddRange(await ProductService.GetAllAsync());
	}


	private async Task WithdrawProduct(ProductDto context)
	{

		NavigationManager.NavigateTo($"/withdrawProducts/{context.Id}");
		
	}

	private async Task UpdateProductStock(int id)
	{
		if ((ProductToUpdate.Quantity - WithdrawalQuantity) >= ProductToUpdate.MinStockLevel)
		{
			ProductToUpdate.Id = id;
			ProductToUpdate.Quantity -= WithdrawalQuantity;

			await ProductService.UpdateAsync(ProductToUpdate, ProductToUpdate.Id);
			ProductDtoList.Clear();
			ProductDtoList.AddRange(await ProductService.GetAllAsync());

			ShowWithdrawalForm = false;
			ShowAllProducts = true;
		}
		else
		{
			TooLowStockLevel = true;

		}
	}

	private string GetQuantityClass(ProductDto product)
	{
		if (product.Quantity <= product.MinStockLevel)
			return "text-danger fw-bold";

		if (product.Quantity <= product.MinStockLevel + 10)
			return "text-warning fw-bold";

		return "";
	}

	private void NavigateToOverview()
	{
		NavigationManager.NavigateTo("/");
	}
}