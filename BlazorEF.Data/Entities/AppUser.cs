using BlazorEF.Data.Enums;
using BlazorEF.Data.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEF.Data.Entities
{
    [Table("AppUsers")]
    public class AppUser : IdentityUser<Guid>,
        IDateTracking, ISwitchable
    {
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public String Avatar { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
