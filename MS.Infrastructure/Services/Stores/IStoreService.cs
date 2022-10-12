using MS.Core.Dtos;
using MS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Stores
{
   public interface IStoreService
    {
        Task<int> Delete(int id);
        Task<StoreViewModel> Get(int Id);
        Task<int> Update(UpdateStoreDto dto);
        Task<int> Create(CreateStoreDto dto);
    }
}
