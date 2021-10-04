using BlazorEF.Application.Interfaces;
using BlazorEF.Application.ViewModels.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEF.API.Controllers
{
    [Route("api/productcategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public List<ProductCategoryViewModel> GetAll()
        {
            return _productCategoryService.GetAll();
        }
    }
}
