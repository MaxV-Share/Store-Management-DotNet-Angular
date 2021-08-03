using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class DiscountController : ApiController
    {
        public readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService, ILogger<DiscountController> logger) : base(logger)
        {
            _discountService = discountService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DiscountCreateRequest request)
        {
            if (request.FromDate <= request.ToDate)
                return BadRequest("Từ ngày không được lớn hơn đến ngày.");
            var result = await _discountService.CreateAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, DiscountUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var result = await _discountService.UpdateAsync(id, request);
            if (result > 0)
                return Ok();
            return Accepted();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _discountService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            var a = await Task.Run(() =>
            {
                return 0;
            });
            return NotFound();

        }

    }
}
