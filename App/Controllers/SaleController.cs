using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.DTOs;
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
        public async Task<ActionResult> Post([FromForm] SaleRequest request)
        {
            var result = await _saleService.PostAsync(request);

            if (result != null)
                return Ok(result);
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
