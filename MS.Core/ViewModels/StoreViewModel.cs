using MS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Core.ViewModels
{
  public  class StoreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LogoUrl { get; set; }
        public UserViewModel Owner { get; set; }
        //public int CategoryId { get; set; }
        //public List<ProductViewModel> Products { get; set; }
        //public List<OfferViewModel> Offers { get; set; }
        //public List<ServiceViewModel> Services { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
