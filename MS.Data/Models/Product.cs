using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
   public class Product : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public float? Price { get; set; }
        public float? Discaount { get; set; }
        public int? StoreId { get; set; }
        public Store Store { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }


    }
}
