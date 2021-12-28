using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using App.Models.DTOs.Categories;
using App.Common.Model;

namespace App.Controllers
{
    public class CategoriesController : CrudController<Category, CategoryCreateRequest, CategoryUpdateRequest, CategoryViewModel, int>
    {
        public readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService, ILogger<CategoriesController> logger) : base(logger, categoryService)
        {
            _categoryService = categoryService;
        }
        public override Task<ActionResult> Post([FromForm] CategoryCreateRequest request)
        {
            return base.Post(request);
        }
        [HttpPost("filter")]
        public override async Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            try
            {
                var result = await _categoryService.GetPagingAsync(request);
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
