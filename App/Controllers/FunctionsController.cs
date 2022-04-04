using App.Common.Model;
using App.Controllers.Base;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using App.Models.DTOs.Functions;

namespace App.Controllers
{
    public class FunctionsController : ApiController
    {
        private readonly IFunctionService _functionService;
        public FunctionsController(ILogger<FunctionsController> logger, IFunctionService functionService) : base(logger)
        {
            _functionService = functionService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FunctionCreateRequest request)
        {
            if (null == request)
                return BadRequest();
            var result = await _functionService.CreateAsync(request);

            if (null == result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, FunctionUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _functionService.UpdateAsync(id, request);
            if (result > 0)
                return NoContent();
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _functionService.DeleteSoftAsync(id);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAll(string searchText = "")
        {
            var result = await _functionService.GetAllDTOAsync();
            return Ok(result);
        }
        [HttpGet("tree-node")]
        public async Task<ActionResult> GetTreeNode()
        {
            var result = await _functionService.GetTreeNodeAsync();
            return Ok(result);
        }
        [HttpGet("tree")]
        public async Task<ActionResult> GetTree()
        {
            var result = await _functionService.GetTreeAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await _functionService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPost("filter")]
        public async Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            var result = await _functionService.GetPagingAsync(request);
            return Ok(result);
        }
        [HttpGet("without-children")]
        public async Task<ActionResult> GetFunctionsWithoutChildren(string textSearch = "")
        {
            var result = await _functionService.GetFunctionsWithoutChildren(textSearch);
            return Ok(result);
        }
    }
}
