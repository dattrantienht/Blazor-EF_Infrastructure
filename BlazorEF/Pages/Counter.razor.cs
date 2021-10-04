using BlazorEF.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BlazorEF.Application.Interfaces;
using BlazorEF.Application.Implementation;
using BlazorEF.API.Controllers;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;

namespace BlazorEF.Pages
{
    public partial class Counter
    {

        public List<ProductCategoryViewModel> productCategories;
        string errorString;
        public string pcname { get; set; }
        private ProductCategoryViewModel newPC = new ProductCategoryViewModel();

        protected override async Task OnInitializedAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get,
                "api/ProductCategory");
            var client = _clientFactory.CreateClient("blazor");
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                productCategories = await response.Content.ReadFromJsonAsync<List<ProductCategoryViewModel>>();
            }
            else
            {
                errorString = $"Error: {response.ReasonPhrase}";
            }
        }
    }
}
