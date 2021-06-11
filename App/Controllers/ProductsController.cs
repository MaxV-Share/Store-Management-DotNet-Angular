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
    }
}
