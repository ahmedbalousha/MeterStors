using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
   public class Store : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        public string OwnerId { get; set; }
        public User Owner { get; set; }
        public List<Product> Products { get; set; }
        public List<Offer> Offers { get; set; }
        public List<Service> Services { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }









    }
}
