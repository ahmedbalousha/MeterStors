using Microsoft.AspNetCore.Mvc;
using MS.API.Controllers;
using MS.Core.Dtos;
using MS.Infrastructure.Services.Categories;
using MS.Infrastructure.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.API.Controllers
{
    public class StoreController : BaseController
    {

        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService) 
        {
            _storeService = storeService;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var user = _storeService.Get(id);
            return Ok(GetResponse(user));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStoreDto dto)
        {
            var savedId = _storeService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateStoreDto dto)
        {
            var savedId = _storeService.Update(dto);
            return Ok(GetResponse(savedId));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _storeService.Delete(id);
            return Ok(GetResponse(deletedId));
        }


    }
}
