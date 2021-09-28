using App.Controllers.Base;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class RevenuesController : ApiController
    {
        private readonly IRevenueService _revenueService;
        public RevenuesController(IRevenueService revenueService, ILogger<RevenuesController> logger) : base(logger)
        {
            _revenueService = revenueService;
        }
        [HttpGet("monthly-of-year")]
        public async Task<ActionResult> GetRevenueMonthlyOfYear(int year)
        {
            var result = await _revenueService.RevenueMonthlyOfYear(year);
            return Ok(result);
        }
        [HttpGet("daily-of-month")]
        public async Task<ActionResult> GetRevenueDailyOfMonth(int year, int month)
        {
            var result = await _revenueService.RevenueDailyOfMonth(year, month);
            return Ok(result);
        }
    }
}
