using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using SS.Model;
using System.ComponentModel.DataAnnotations;

namespace SS.Mvc.GiftShopApp.Core.Models
{
    public class Role : Entity, IRole<int>
    {
        [Required]
        [StringLength(50)]

        public const string Admin = "Admin";
        public const string Client = "Client";
        [Display(Name = "Role")]
        public virtual string Name { get; set; }

        public virtual ICollection<UserRole> Users { get; set; }

        public static IEnumerable<string> All()
        {
            return new[] { Admin, Client };
        }

    }
}







