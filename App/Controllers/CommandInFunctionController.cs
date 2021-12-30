using App.Controllers.Base;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using App.Common.Model;

namespace App.Controllers
{
    public class CommandInFunctionController : ApiController
    {
        private readonly ICommandInFunctionService _commandInFunctionService;
        public CommandInFunctionController(ILogger<CommandInFunctionController> logger, ICommandInFunctionService commandInFunctionService) : base(logger)
        {
            _commandInFunctionService = commandInFunctionService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CommandInFunctionCreateRequest request)
        {
            if (null == request)
                return BadRequest();
            var result = await _commandInFunctionService.CreateAsync(request);

            if (null == result)
                return StatusCode(StatusCodes.Status500InternalServerError);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, CommandInFunctionUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _commandInFunctionService.UpdateAsync(id, request);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var result = await _commandInFunctionService.DeleteSoftAsync(id);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAll(string searchText = "")
        {
            var result = await _commandInFunctionService.GetAllDTOAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var result = await _commandInFunctionService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPost("filter")]
        public async Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            try
            {
                var result = await _commandInFunctionService.GetPagingAsync(request);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
