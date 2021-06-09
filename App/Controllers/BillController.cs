using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Controllers.Base;
using App.Models.DTOs;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class BillController : ApiController
    {
        public readonly IBillService _billService;
        public BillController(IBillService saleService)
        {
            _billService = saleService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] BillCreateRequest request)
        {
            var result = await _billService.PostAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
    }
}
