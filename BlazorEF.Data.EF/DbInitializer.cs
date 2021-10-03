using BlazorEF.Data.Entities;
using BlazorEF.Data.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.Data.EF
{
    public class DbInitializer
    {
        private readonly AppDbContext _context;
        private UserManager<AppUser> _userManager;
        private RoleManager<AppRole> _roleManager;
        public DbInitializer(AppDbContext context, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin",
                    NormalizedName = "Admin",
                    Description = "Top manager"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Staff",
                    NormalizedName = "Staff",
                    Description = "Staff"
                });
                await _roleManager.CreateAsync(new AppRole()
                {
                    Name = "Customer",
                    NormalizedName = "Customer",
                    Description = "Customer"
                });
            }
            if (!_userManager.Users.Any())
            {
                await _userManager.CreateAsync(new AppUser()
                {
                    UserName = "admin",
                    FullName = "Administrator",
                    Email = "admin@gmail.com",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    Status = Status.Active
                }, "Dat123654$");
                var user = await _userManager.FindByNameAsync("admin");
                await _userManager.AddToRoleAsync(user, "Admin");
            }
            if (_context.functions.Count() == 0)
            {
                _context.functions.AddRange(new List<Function>()
                {
                    new Function() {Id = "SYSTEM", Name = "System",ParentId = null,SortOrder = 1,Status = Status.Active,URL = "/",IconCss = "fa-desktop"  },
                    new Function() {Id = "ROLE", Name = "Role",ParentId = "SYSTEM",SortOrder = 1,Status = Status.Active,URL = "/admin/role/index",IconCss = "fa-home"  },
                    new Function() {Id = "FUNCTION", Name = "Function",ParentId = "SYSTEM",SortOrder = 2,Status = Status.Active,URL = "/admin/function/index",IconCss = "fa-home"  },
                    new Function() {Id = "USER", Name = "User",ParentId = "SYSTEM",SortOrder =3,Status = Status.Active,URL = "/admin/user/index",IconCss = "fa-home"  },
                    new Function() {Id = "ACTIVITY", Name = "Activity",ParentId = "SYSTEM",SortOrder = 4,Status = Status.Active,URL = "/admin/activity/index",IconCss = "fa-home"  },
                    new Function() {Id = "ERROR", Name = "Error",ParentId = "SYSTEM",SortOrder = 5,Status = Status.Active,URL = "/admin/error/index",IconCss = "fa-home"  },
                    new Function() {Id = "SETTING", Name = "Configuration",ParentId = "SYSTEM",SortOrder = 6,Status = Status.Active,URL = "/admin/setting/index",IconCss = "fa-home"  },

                    new Function() {Id = "PRODUCT",Name = "Product Management",ParentId = null,SortOrder = 2,Status = Status.Active,URL = "/",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_CATEGORY",Name = "Category",ParentId = "PRODUCT",SortOrder =1,Status = Status.Active,URL = "/admin/productcategory/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "PRODUCT_LIST",Name = "Product",ParentId = "PRODUCT",SortOrder = 2,Status = Status.Active,URL = "/admin/product/index",IconCss = "fa-chevron-down"  },
                    new Function() {Id = "BILL",Name = "Bill",ParentId = "PRODUCT",SortOrder = 3,Status = Status.Active,URL = "/admin/bill/index",IconCss = "fa-chevron-down"  },

                    new Function() {Id = "CONTENT",Name = "Content",ParentId = null,SortOrder = 3,Status = Status.Active,URL = "/",IconCss = "fa-table"  },
                    new Function() {Id = "BLOG",Name = "Blog",ParentId = "CONTENT",SortOrder = 1,Status = Status.Active,URL = "/admin/blog/index",IconCss = "fa-table"  },
                    new Function() {Id = "PAGE",Name = "Page",ParentId = "CONTENT",SortOrder = 2,Status = Status.Active,URL = "/admin/page/index",IconCss = "fa-table"  },

                    new Function() {Id = "UTILITY",Name = "Utilities",ParentId = null,SortOrder = 4,Status = Status.Active,URL = "/",IconCss = "fa-clone"  },
                    new Function() {Id = "FOOTER",Name = "Footer",ParentId = "UTILITY",SortOrder = 1,Status = Status.Active,URL = "/admin/footer/index",IconCss = "fa-clone"  },
                    new Function() {Id = "FEEDBACK",Name = "Feedback",ParentId = "UTILITY",SortOrder = 2,Status = Status.Active,URL = "/admin/feedback/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ANNOUNCEMENT",Name = "Announcement",ParentId = "UTILITY",SortOrder = 3,Status = Status.Active,URL = "/admin/announcement/index",IconCss = "fa-clone"  },
                    new Function() {Id = "CONTACT",Name = "Contact",ParentId = "UTILITY",SortOrder = 4,Status = Status.Active,URL = "/admin/contact/index",IconCss = "fa-clone"  },
                    new Function() {Id = "SLIDE",Name = "Slide",ParentId = "UTILITY",SortOrder = 5,Status = Status.Active,URL = "/admin/slide/index",IconCss = "fa-clone"  },
                    new Function() {Id = "ADVERTISMENT",Name = "Advertisment",ParentId = "UTILITY",SortOrder = 6,Status = Status.Active,URL = "/admin/advertistment/index",IconCss = "fa-clone"  },

                    new Function() {Id = "REPORT",Name = "Report",ParentId = null,SortOrder = 5,Status = Status.Active,URL = "/",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "REVENUES",Name = "Revenue report",ParentId = "REPORT",SortOrder = 1,Status = Status.Active,URL = "/admin/report/revenues",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "ACCESS",Name = "Visitor Report",ParentId = "REPORT",SortOrder = 2,Status = Status.Active,URL = "/admin/report/visitor",IconCss = "fa-bar-chart-o"  },
                    new Function() {Id = "READER",Name = "Reader Report",ParentId = "REPORT",SortOrder = 3,Status = Status.Active,URL = "/admin/report/reader",IconCss = "fa-bar-chart-o"  },
                });
            }
            if (_context.productCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name="Handguns",SeoAlias="handguns",ParentId = null,Status=Status.Active,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Beretta M9",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Colt M1911",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Glock 30",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Pardini GT9",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "The Luger",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new ProductCategory() { Name="Assault Rifles",SeoAlias="assault-rifles",ParentId = null,Status=Status.Active,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "AK-47",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "StG 44",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "M4A1",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "AR15",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "G36",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }},
                    new ProductCategory() { Name="Machine guns",SeoAlias="machine-guns",ParentId = null,Status=Status.Active,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "AA-52",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Breda 38",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Daewoo K3",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Gatling gun",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "GAU-19",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }},
                    new ProductCategory() { Name="Sniper rifles",SeoAlias="sniper-rifles",ParentId = null,Status=Status.Active,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Armalite AR-50",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Barrett M99",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Dragunov SVU",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "DSR-1",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "AWM",DateCreated=DateTime.Now,Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }}
                };
                _context.productCategories.AddRange(listProductCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}
