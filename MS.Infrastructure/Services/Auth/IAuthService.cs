using MS.Core.Dtos;
using MS.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Auth
{
   public interface IAuthService
    {
        Task<LoginResponseViewModel> Login(LoginDto dto);
    }
}
