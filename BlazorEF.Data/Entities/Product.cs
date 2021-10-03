using BlazorEF.Data.Enums;
using BlazorEF.Data.Interfaces;
using BlazorEF.Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.Data.Entities
{
    [Table("Products")]
    public class Product : DomainEntity<int>,
        ISwitchable, IDateTracking, IHasSeoMetaData
    {
        [StringLength(255)]
        [Required]
        public string Name { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        [DefaultValue(0)]
        public double Price { get; set; }
        public double? PromotionPrice { get; set; }
        public double? OriginalPrice { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        public string Content { get; set; }
        public bool? HomeFlag { get; set; }
        public bool? HotFlag { get; set; }
        public int? ViewCount { get; set; }
        [StringLength(255)]
        public string Tags { get; set; }
        public string Unit { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

        public string SeoPageTitle { get; set; }
        [StringLength(255)]
        public string SeoAlias { get; set; }
        [StringLength(255)]
        public string SeoKeywords { get; set; }
        public string SeoDescription { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }
    }
}
