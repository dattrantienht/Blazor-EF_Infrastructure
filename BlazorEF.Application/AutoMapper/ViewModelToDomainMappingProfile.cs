using AutoMapper;
using BlazorEF.Application.ViewModels.Product;
using BlazorEF.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProductCategoryViewModel, ProductCategory>()
                .ConstructUsing(c => new ProductCategory(
                    c.Name,
                    c.Description,
                    c.ParentId,
                    c.HomeOrder,
                    c.Image, 
                    c.HomeFlag,
                    c.Status, 
                    c.SeoPageTitle, 
                    c.SeoAlias, 
                    c.SeoKeywords, 
                    c.SeoDescription
                    ));
        }
    }
}
