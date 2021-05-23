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
    public class CustomerController : ApiController
    {
        public readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] CustomerRequest request)
        {
            var result = await _customerService.PostAsync(request);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _customerService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }
        [HttpPatch]
        public async Task<ActionResult> Put(Guid uuid, CustomerNonRequest request)
        {
            if (uuid != request.Uuid)
                return BadRequest();
            var result = await _customerService.PutAsync(uuid, request);
            if (result > 0)
                return Ok();
            return NotFound();
        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _customerService.DeleteSoftAsync(id);
            if (result == 1)
                return Ok();
            return BadRequest();
        }
    }
}
