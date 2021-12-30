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
using App.Models.DTOs.Langs;

namespace App.Controllers
{
    public class LangsController : ApiController
    {
        public readonly ILangService _langService;
        public LangsController(ILangService langService, ILogger<CategoriesController> logger) : base(logger)
        {
            _langService = langService;
        }
        [HttpPost("filter")]
        public async Task<ActionResult> GetAllFilter(LangFilterRequest request)
        {
            var result = await _langService.GetPagingAsync(request);
            return Ok(result);
        }
    }
}
