using App.Controllers.Base;
using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
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

    public class ProductsController : CRUDContoller<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger) : base(logger, productService)
        {
            _productService = productService;
        }
        [HttpGet("filter")]
        public async Task<ActionResult> GetAllFilter(string langId = "vi", string searchText = "")
        {
            return Ok(await _productService.GetAllDTOAsync(langId, searchText));
        }

        [HttpGet("filter-paging")]
        public async Task<ActionResult> GetPaging(int pageIndex, int pageSize, string langId, string searchText = "")
        {
            var result = await _productService.GetPagingAsync(langId, pageIndex, pageSize, searchText);
            return Ok(result);
        }
    }
}
