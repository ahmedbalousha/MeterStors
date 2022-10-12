﻿using Microsoft.AspNetCore.Mvc;
using MS.API.Controllers;
using MS.Core.Dtos;
using MS.Infrastructure.Services.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS.API.Controllers
{
    public class CategoryController : BaseController
    {

        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult GetAll(/*string serachkey*/)
        {
            var categories = _categoryService.GetAllAPI(/*serachkey*/);
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryDto dto)
        {
            var savedId = _categoryService.Create(dto);
            return Ok(GetResponse(savedId));
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var savedId = _categoryService.Update(dto);
            return Ok(GetResponse(savedId));
        }


        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var deletedId = _categoryService.Delete(id);
            return Ok(GetResponse(deletedId));
        }


    }
}
