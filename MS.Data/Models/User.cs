using Microsoft.AspNetCore.Identity;
using MS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
   public class User : IdentityUser
    {
        [Required]
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string ImageUrl { get; set; }
        public UserType UserType { get; set; }
        public bool IsDelete { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public List<Store> Stores { get; set; }
        public List<Advertisement> Advertisements { get; set; }
        public List<Order> Orders { get; set; }






    }
}
