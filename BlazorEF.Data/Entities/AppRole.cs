using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.Data.Entities
{
    [Table("AppRoles")]
    public class AppRole : IdentityRole<Guid>
    {
        public AppRole() : base()
        {

        }
        public AppRole(string name, string description):base(name)
        {
            this.Description = description;
        }
        public string Description { get; set; }
    }
}
