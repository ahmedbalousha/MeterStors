using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
  public class Advertisement : BaseEntity
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string WebsiteUrl { get; set; }
        public float Price { get; set; }
        public string AdvertiserId { get; set; }
        public User Advertiser { get; set; }

    }
}
