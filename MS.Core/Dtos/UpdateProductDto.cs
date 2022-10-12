using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Core.Dtos
{
    public class UpdateProductDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public float? Price { get; set; }
        public float? Discaount { get; set; }
        public int? StoreId { get; set; }
        public int? OrderId { get; set; }
        public int? CategoryId { get; set; }
    }
}
