using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class CategoriesController : CRUDContoller<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger) : base(logger, categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("filter")]
        public async Task<ActionResult> GetAllFilter(string searchText = "", string langId = "vi")
        {
            var result = await _categoryService.GetAllDTOAsync(langId, searchText);
            return Ok(result);
        }
        [HttpGet("filter-paging")]
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
