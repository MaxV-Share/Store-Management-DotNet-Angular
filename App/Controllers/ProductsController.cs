using App.Controllers.Base;
using App.Models.DTOs;
using App.Models.DTOs.CreateRequests;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using App.Models.DTOs.Products;
using App.Models.DbContexts;
using App.Common.Model;


namespace App.Controllers
{

    public class ProductsController : CrudController<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger, ApplicationDbContext context) : base(logger, productService)
        {
            _productService = productService;
        }
        [HttpPut("import")]
        public async Task<ActionResult> ImportProduct([FromForm] ProductImport files)
        {
            await _productService.ImportProducts(files.File);
            return Ok(files);
        }

        [HttpPut("{id}")]
        public override async Task<ActionResult> Put(int id, [FromForm] ProductUpdateRequest request)
        {
            if (id != request.Id)
                return BadRequest();
            var effectedCount = await _productService.UpdateAsync(id, request);
            if (effectedCount > 0)
                return Ok();
            return Accepted();
        }

        [HttpPost("filter")]
        public override async Task<ActionResult> GetPaging(FilterBodyRequest request)
        {
            return Ok(await _productService.GetPagingAsync(request));
        }

    }
}
