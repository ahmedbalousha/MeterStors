using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Data.Models
{
   public class Order : BaseEntity
    {
        public int Id { get; set; }
        public string BuyerId { get; set; }
        public User Buyer { get; set; }
        public List<Product> Products { get; set; }
        public int CouponId { get; set; }
        public Coupon Coupon { get; set; }



    }
}
