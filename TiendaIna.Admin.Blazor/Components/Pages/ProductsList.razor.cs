using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using TiendaIna.Core.Model;
using TiendaIna.Core.Services;

public class ProductsListModel : ComponentBase
{
    [Inject] private IProductsService ProductsService { get; set; }

    public List<ProductModel> products { get; set; }

    protected override async Task OnInitializedAsync()
    {
        products = await ProductsService.GetProducts() ?? new();
    }

}
