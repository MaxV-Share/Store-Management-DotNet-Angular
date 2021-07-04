using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.Bills;
using App.Models.DTOs.CreateRequest;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BillsController : ApiController
    {
        public readonly IBillService _billService;
        public readonly IBillDetailService _billDetailService;
        public BillsController(IBillService billService, IBillDetailService billDetailService)
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
            var result = await _billService.UpdateAsync(id, request);
            return Ok();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _billService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("{billId}/details")]
        public async Task<ActionResult> GetBillDetailByBillId(int billId, string langId)
        {
            var result = await _billDetailService.GetByBillIdAsync(billId, langId);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _billService.GetAllDTOAsync();

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("filter")]
        public async Task<ActionResult> GetAllPaging(int pageIndex, int pageSize)
        {
            var result = await _billService.GetPaging(pageIndex, pageSize);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}
