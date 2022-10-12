using Microsoft.AspNetCore.Mvc;
using MS.Core.Dtos;
using MS.Core.RequestFeatures;
using MS.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MS.Infrastructure.Services.Users
{
  public  interface IUserService
    {
        Task<List<UserViewModel>> GetAll([FromQuery] UserParameters userParameters);
        Task<string> Update (UpdateUserDto dto);
        Task<UserViewModel> Get(string id);
        Task<string> Create(CreateUserDto dto);
        Task<string> Delete(string Id);
        UserViewModel GetUserByUsername(string username);
    }
}
