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
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryCreateRequest request)
        {
            if (null == request)
                return BadRequest();
            var result = await _categoryService.CreateAsync(request);

            if (null == result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CategoryViewModel request)
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
        [HttpGet("filter")]
        public async Task<ActionResult> GetPaging(int pageIndex, int pageSize, string langId, string searchText = "")
        {
            var result = await _categoryService.GetPaging(langId, pageIndex, pageSize, searchText);
            return Ok(result);
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAll(string langId = "vi")
        {
            var result = await _categoryService.GetAllDTOAsync(langId);
            return Ok(result);
        }
    }
}
