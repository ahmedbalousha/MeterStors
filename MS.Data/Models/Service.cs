using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
  public class Service : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Body { get; set; }
        public string ImageUrl { get; set; }
        public float Price { get; set; }
        public int StoreId { get; set; }
        public Store Store { get; set; }

    }
}
