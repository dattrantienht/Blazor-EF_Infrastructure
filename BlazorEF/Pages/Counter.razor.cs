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

namespace BlazorEF.Pages
{
    public partial class Counter
    {
       
        private List<ProductCategoryViewModel> productCategories;
        public string pcname { get; set; }
        private ProductCategoryViewModel newPC = new ProductCategoryViewModel();
        
        protected override void OnInitialized()
        {
            productCategories = _productCategoryController.GetAll();
            base.OnInitialized();
        }

        private void testBinding()
        {
            Console.WriteLine(pcname);
            newPC.Name = pcname;
            _productCategoryController.Add(newPC);
            productCategories = _productCategoryController.GetAll();
        }

    }
}
