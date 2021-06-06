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
    public class CategoriesController : ApiController
    {
        public readonly ICategoriesService _categoryService;
        public CategoriesController(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryCR request)
        {
            if (request == null)
                return BadRequest();
            var result = await _categoryService.CreateAsync(request);
            
            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CategoryVm request)
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
        [HttpGet("")]
        public async Task<ActionResult> GetPaging(int pageIndex, int pageSize, string langId, string searchText = "")
        {
            var result = await _categoryService.GetPaging(langId, pageIndex, pageSize, searchText);
            return Ok(result);
        }
    }
}
