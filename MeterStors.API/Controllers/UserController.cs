using Microsoft.AspNetCore.Mvc;
using MS.Core.Dtos;
using MS.Core.RequestFeatures;
using MS.Data.Models;
using MS.Infrastructure.Services;
using MS.Infrastructure.Services.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task <IActionResult> GetAll([FromQuery]
         UserParameters userParameters)
        {
            var users =  _userService.GetAll(userParameters);
            return Ok(GetResponse(users));
        }
        [HttpPut]
        public IActionResult Update ([FromBody]UpdateUserDto dto)
        {
            var updateId = _userService.Update(dto);
            return Ok(GetResponse(updateId));
        }
        [HttpGet]
        public async Task<IActionResult> Get(string id)
        {
            var user = await _userService.Get(id);
            return Ok(GetResponse(user));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var savedId = await _userService.Create(dto);
            return Ok(GetResponse(savedId));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
           var deletedId = await _userService.Delete(id);
            return Ok(GetResponse(deletedId));
        }
    }
}
