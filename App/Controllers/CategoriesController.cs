using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class CategoriesController : ApiController
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger) : base(logger)
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
        public async Task<ActionResult> Put(int id, CategoryUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _categoryService.UpdateAsync(id, request);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAll(string langId = "vi", string searchText = "")
        {
            var result = await _categoryService.GetAllDTOAsync(langId, searchText);
            return Ok(result);
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
            try
            {
                var result = await _categoryService.GetDetailsPagingAsync(langId, pageIndex, pageSize, searchText);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
