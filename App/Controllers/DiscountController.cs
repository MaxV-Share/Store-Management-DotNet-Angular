using App.Controllers.Base;
using App.DTOs;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class DiscountController : CRUDContoller<Discount, DiscountCreateRequest, DiscountUpdateRequest, DiscountViewModel, int>
    {
        public readonly IDiscountService _discountService;
        public DiscountController(IDiscountService discountService, ILogger<DiscountController> logger) : base(logger, discountService)
        {
            _discountService = discountService;
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
