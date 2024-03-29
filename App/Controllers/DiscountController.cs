﻿using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Common.Model;

namespace App.Controllers
{
    public class DiscountController : CrudController<Discount, DiscountCreateRequest, DiscountUpdateRequest, DiscountViewModel, int>
    {
        public readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService, ILogger<DiscountController> logger) : base(logger, discountService)
        {
            _discountService = discountService;
        }
        [HttpPost("filter")]
        public override Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            throw new System.NotImplementedException();
        }

        [HttpPost]
        public override async Task<ActionResult> Post([FromBody] DiscountCreateRequest request)
        {
            if (request.FromDate <= request.ToDate)
                return BadRequest("Từ ngày không được lớn hơn đến ngày.");
            var result = await _discountService.CreateAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

    }
}
