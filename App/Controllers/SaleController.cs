using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.DTOs;
using App.Models.DTOs;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class SaleController : ApiController
    {
        public readonly ISaleService _saleService;
        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SaleRequest request)
        {
            if (request.FromDate <= request.ToDate)
                return BadRequest("Từ ngày không được lớn hơn đến ngày.");
            var result = await _saleService.PostAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, SaleNonRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _saleService.PutAsync(id, request);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _saleService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}
