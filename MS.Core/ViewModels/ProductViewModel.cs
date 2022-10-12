using MS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Core.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public float? Price { get; set; }
        public float? Discaount { get; set; }
        public StoreViewModel Store { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}
