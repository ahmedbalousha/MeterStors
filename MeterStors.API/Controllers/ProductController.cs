using Microsoft.AspNetCore.Mvc;
using MS.Infrastructure.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MS.Core.Dtos;
using MS.API.Controllers;

namespace MeterStors.API.Controllers
{
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            var product = _productService.Get(id);
            return Ok(GetResponse(product));
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateProductDto dto)
        {
            var savedId = _productService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto dto)
        {
            var savedId = _productService.Update(dto);
            return Ok(GetResponse(savedId));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _productService.Delete(id);
            return Ok(GetResponse(deletedId));
        }
    }
}
