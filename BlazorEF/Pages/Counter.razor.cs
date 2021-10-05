using BlazorEF.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorEF.Pages
{
    public partial class Counter
    {
        public List<ProductCategoryViewModel> productCategories;
        private string errorString;
        public string pcname { get; set; }
        private ProductCategoryViewModel newPC = new ProductCategoryViewModel();

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(getPC);
        }

        public async Task getPC()
        {
            var client = _clientFactory.CreateClient("blazor");
            try
            {
                productCategories = await client.GetFromJsonAsync<List<ProductCategoryViewModel>>("ProductCategory");
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"Error: {ex.Message}";
            }
        }
    }
}