using App.Controllers.Base;
using App.Models.DTOs;
using App.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Controllers
{

    public class ProductsController : ApiController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService) 
        {
            _productService = productService;
        }

        [Route("")]
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] ProductCreateRequest request)
        {
            await _productService.CreateAsync(request);
            return Ok();
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

        [HttpGet("")]
        public async Task<ActionResult> GetAll(string langId = "vi", string searchText = "")
        {
            return Ok(await _productService.GetAllDTOAsync(langId, searchText));
        }
    }
}
