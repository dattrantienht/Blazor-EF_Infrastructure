using BlazorEF.Data.Enums;
using BlazorEF.Data.Interfaces;
using BlazorEF.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorEF.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory : DomainEntity<int>,
        IHasSeoMetaData, ISwitchable, ISortable, IDateTracking
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public string Image { get; set; }
        public bool? HomeFlag { get; set; }

        DateTime IDateTracking.DateCreated { get; set; }
        DateTime IDateTracking.DateModified { get; set; }
        int ISortable.SortOrder { get; set; }
        Status ISwitchable.Status { get; set; }
        string IHasSeoMetaData.SeoPageTitle { get; set; }
        string IHasSeoMetaData.SeoAlias { get; set; }
        string IHasSeoMetaData.SeoKeywords { get; set; }
        string IHasSeoMetaData.SeoDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}