using App.Controllers.Base;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequests;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class BillsController : ApiController
    {
        public readonly IBillService _billService;
        public readonly IBillDetailService _billDetailService;
        public BillsController(IBillService billService, IBillDetailService billDetailService, ILogger<BillsController> logger) : base(logger)
        {
            _billService = billService;
            _billDetailService = billDetailService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BillCreateRequest request)
        {
            var result = await _billService.CreateAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] BillViewModel request)
        {
            try
            {
                var result = await _billService.UpdateAsync(id, request);
                if (result <= 0)
                    return BadRequest();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError("object error", request);
                _logger.LogError(ex.Message);
                _logger.LogError(ex.StackTrace);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _billService.DeleteSoftAsync(id);
            if (result >= 0)
                return Ok(result);
            return NotFound();
        }
        //[HttpGet("")]
        //public async Task<ActionResult> GetAll() // 
        //{
        //    var result = await _billService.GetAllDTOAsync();

        //    if (result != null)
        //        return Ok(result);
        //    return NotFound();
        //}

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _billService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("{id}/bill-details")]// bills/1/bill-details
        public async Task<ActionResult> GetBillDetailByBillId(int id, string langId)
        {
            var result = await _billDetailService.GetByBillIdAsync(id, langId);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("paging")]// bills?paging=true&pageIndex=1&pageSize=5......
        public async Task<ActionResult> GetAllPaging(string txtSearch, int pageIndex = 0, int pageSize = 100)
        {
            var result = await _billService.GetPagingAsync(pageIndex, pageSize, txtSearch);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}
