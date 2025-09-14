using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.QuickGrid;
using StockCare.Client.ServiceInterfaces;
using StockCare.DTOs.DTOs.Product;

namespace StockCare.Client.Components.Pages;

public partial class Products : ComponentBase
{
	[Inject] private IProductService ProductService { get; set; }
	[Inject] private NavigationManager NavigationManager { get; set; }
	private List<ProductDto> ProductDtoList { get; set; } = [];
	private ProductDto ProductDto { get; set; } = new();
	private readonly PaginationState _paginationState = new PaginationState { ItemsPerPage = 5 };

	protected override async Task OnInitializedAsync()
	{
		ProductDtoList.AddRange(await ProductService.GetAllAsync());

		await base.OnInitializedAsync();
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
		Console.WriteLine("Button clicked!"); // Debug check
		NavigationManager.NavigateTo("/newProduct");
	}
}