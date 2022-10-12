using MS.Core.Dtos;
using MS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Products
{
   public interface IProductService
    {
        Task<int> Delete(int id);
        Task<ProductViewModel> Get(int Id);
        Task<int> Create(CreateProductDto dto);
        Task<int> Update(UpdateProductDto dto);
    }
}
