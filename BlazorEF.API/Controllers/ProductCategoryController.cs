using BlazorEF.Application.Interfaces;
using BlazorEF.Application.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorEF.API.Controllers
{
    public class ProductCategoryController : ApiController
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService )
        {
            _productCategoryService = productCategoryService;
        }


        [HttpGet]
        public ActionResult<List<ProductCategoryViewModel>> GetAll()
        {
            var data = _productCategoryService.GetAll();
            if (data is null)
            {
                return NotFound("Get product category failed (╥﹏╥)");
            }
            return data;
        }


        [HttpGet("id={id}")]
        public ActionResult<ProductCategoryViewModel> GetById(int id)
        {
            var data = _productCategoryService.GetById(id);
            if(data is null)
            {
                return NotFound("Get product category failed (╥﹏╥)");
            }
            return data;
        }

        [HttpPost]
        public void Add(ProductCategoryViewModel productCategoryVm)
        {
            _productCategoryService.Add(productCategoryVm);
            _productCategoryService.Save();
        }
    }
}
