using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.Models.DTOs;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class CategoryController : ApiController
    {
        public readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryRequest request)
        {
            var result = await _categoryService.PostAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, CategoryNonRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _categoryService.PutAsync(id, request);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _categoryService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}
