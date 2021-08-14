using App.Controllers.Base;
using App.DTOs;
using App.Infrastructures.Dbcontexts;
using App.Models.DTOs;
using App.Models.DTOs.Imports;
using App.Models.DTOs.UpdateRquests;
using App.Models.Entities;
using App.Services.Interface;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace App.Controllers
{

    public class ProductsController : CRUDContoller<Product, ProductCreateRequest, ProductUpdateRequest, ProductViewModel, int>
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, ILogger<ProductsController> logger,ApplicationDbContext context) : base(logger, productService)
        {
            _productService = productService;
        }
        [HttpGet("filter")]
        public async Task<ActionResult> GetAllFilter(string langId = "vi", string searchText = "")
        {
            var result = await _productService.GetAllDTOAsync(langId, searchText);
            return Ok(result);
        }
        [HttpPut("import")]
        public async Task<ActionResult> ImportProduct([FromForm] ProductImport files)
        {
            await _productService.ImportProducts(files.File);
            return Ok(files);
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
            //if (!_context.Functions.Any())
            //{
            //    _context.Functions.AddRange(new List<Function>
            //    {
            //        new Function {Id = "DASHBOARD", Name = "Thống kê", ParentId = null, SortOrder = 1,Url = "/dashboard",Icon="fa-dashboard" },

            //        new Function {Id = "CONTENT",Name = "Nội dung",ParentId = null,Url = "/contents",Icon="fa-table" },

            //        new Function {Id = "CONTENT_CATEGORY",Name = "Danh mục",ParentId ="CONTENT",Url = "/contents/categories"  },
            //        new Function {Id = "CONTENT_KNOWLEDGEBASE",Name = "Bài viết",ParentId = "CONTENT",SortOrder = 2,Url = "/contents/knowledge-bases",Icon="fa-edit" },
            //        new Function {Id = "CONTENT_COMMENT",Name = "Trang",ParentId = "CONTENT",SortOrder = 3,Url = "/contents/comments",Icon="fa-edit" },
            //        new Function {Id = "CONTENT_REPORT",Name = "Báo xấu",ParentId = "CONTENT",SortOrder = 3,Url = "/contents/reports",Icon="fa-edit" },

            //        new Function {Id = "STATISTIC",Name = "Thống kê", ParentId = null, Url = "/statistics",Icon="fa-bar-chart-o" },

            //        new Function {Id = "STATISTIC_MONTHLY_NEWMEMBER",Name = "Đăng ký từng tháng",ParentId = "STATISTIC",SortOrder = 1,Url = "/statistics/monthly-registers",Icon = "fa-wrench"},
            //        new Function {Id = "STATISTIC_MONTHLY_NEWKB",Name = "Bài đăng hàng tháng",ParentId = "STATISTIC",SortOrder = 2,Url = "/statistics/monthly-newkbs",Icon = "fa-wrench"},
            //        new Function {Id = "STATISTIC_MONTHLY_COMMENT",Name = "Comment theo tháng",ParentId = "STATISTIC",SortOrder = 3,Url = "/statistics/monthly-comments",Icon = "fa-wrench" },

            //        new Function {Id = "SYSTEM", Name = "Hệ thống", ParentId = null, Url = "/systems",Icon="fa-th-list" },

            //        new Function {Id = "SYSTEM_USER", Name = "Người dùng",ParentId = "SYSTEM",Url = "/systems/users",Icon="fa-desktop"},
            //        new Function {Id = "SYSTEM_ROLE", Name = "Nhóm quyền",ParentId = "SYSTEM",Url = "/systems/roles",Icon="fa-desktop"},
            //        new Function {Id = "SYSTEM_FUNCTION", Name = "Chức năng",ParentId = "SYSTEM",Url = "/systems/functions",Icon="fa-desktop"},
            //        new Function {Id = "SYSTEM_PERMISSION", Name = "Quyền hạn",ParentId = "SYSTEM",Url = "/systems/permissions",Icon="fa-desktop"},
            //    });
            //    await _context.SaveChangesAsync();
            //}
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
