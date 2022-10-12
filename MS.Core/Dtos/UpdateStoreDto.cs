using MS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Core.Dtos
{
   public class UpdateStoreDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LogoUrl { get; set; }
        public string OwnerId { get; set; }
        public int CategoryId { get; set; }
    }
}
