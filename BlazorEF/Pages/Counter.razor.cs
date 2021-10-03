using BlazorEF.Application.ViewModels.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using BlazorEF.Application.Interfaces;
using BlazorEF.Application.Implementation;

namespace BlazorEF.Pages
{
    public partial class Counter
    {

        private List<ProductCategoryViewModel> productCategories;
        protected override void OnInitialized()
        {
            productCategories = _productService.GetAll();
            base.OnInitialized();
        }

        public string pcname { get; set; }
        private ProductCategoryViewModel newPC = new ProductCategoryViewModel();
        private void testBinding()
        {
            Console.WriteLine(pcname);
            newPC.Name = pcname;
            _productService.Add(newPC);
            _productService.Save();
            productCategories = _productService.GetAll();
        }

        

    }
}
