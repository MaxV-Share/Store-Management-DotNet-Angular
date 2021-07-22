using App.Controllers.Base;
using App.Models.DTOs;
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

    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger) : base(logger)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProductCreateRequest request)
        {
            await _productService.CreateAsync(request);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromForm] ProductViewModel request)
        {
            if(id != request.Id)
                return BadRequest();
            var effectedCount = await _productService.UpdateAsync(id, request);
            if(effectedCount > 0)
                return Ok();
            return Accepted();
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAll(string langId = "vi", string searchText = "")
        {
            return Ok(await _productService.GetAllDTOAsync(langId, searchText));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);

            if (result != null)
                return Ok(result);
            return NotFound();
        }

        [HttpGet("filter")]
        public async Task<ActionResult> GetPaging(int pageIndex, int pageSize, string langId, string searchText = "")
        {
            var result = await _productService.GetPagingAsync(langId, pageIndex, pageSize, searchText);
            return Ok(result);
        }
    }
}
