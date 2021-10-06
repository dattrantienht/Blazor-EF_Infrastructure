using BlazorEF.Application.ViewModels.Product;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorEF.Pages
{
    public partial class TestAPI
    {
        [Inject]
        public IHttpClientFactory _clientFactory { get; set; }

        public List<ProductCategoryViewModel> listProductCategories;
        private ProductCategoryViewModel productCategory;
        private string errorString;
        private string errorString2;
        private string errorString3;
        private string errorString4;

        public string pcname { get; set; }
        private ProductCategoryViewModel newPC = new ProductCategoryViewModel();
        private int PCid;
        private string newPcName;
        private string editName;
        private int editId;

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(getPC);
        }

        public async Task getPC()
        {
            var client = _clientFactory.CreateClient("blazor");
            try
            {
                listProductCategories = await client.GetFromJsonAsync<List<ProductCategoryViewModel>>("ProductCategory");
                errorString = null;
            }
            catch (Exception ex)
            {
                errorString = $"Error: {ex.Message}";
            }
        }

        public async Task getPCbyID()
        {
            var client = _clientFactory.CreateClient("blazor");
            try
            {
                productCategory = await client.GetFromJsonAsync<ProductCategoryViewModel>($"ProductCategory/id={PCid}");
                errorString2 = null;
            }
            catch (Exception ex)
            {
                errorString2 = $"Error: {ex.Message}";
            }
        }

        public async Task Add()
        {
            var client = _clientFactory.CreateClient("blazor");
            try
            {
                newPC.Name = newPcName;
                await client.PostAsJsonAsync<ProductCategoryViewModel>($"ProductCategory", newPC);
                await Task.Run(getPC);
                newPcName = "";
                errorString3 = null;
            }
            catch (Exception ex)
            {
                errorString3 = $"Error: {ex.Message}";
            }
        }

        public async Task Edit()
        {
            var client = _clientFactory.CreateClient("blazor");
            try
            {
                newPC.Name = editName;
                newPC.Id = editId;
                await client.PutAsJsonAsync<ProductCategoryViewModel>($"ProductCategory", newPC);
                await Task.Run(getPC);
                editName = "";
                editId = 0;
                errorString4 = null;
            }
            catch (Exception ex)
            {
                errorString4 = $"Error: {ex.Message}";
            }
        }


        private void getDataForModal(string name,int id)
        {
            editName = name;
            editId = id;
        }


    }
}