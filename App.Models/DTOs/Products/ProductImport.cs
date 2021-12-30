using Microsoft.AspNetCore.Http;

namespace App.Models.DTOs.Products
{
    public class ProductImport
    {
        public IFormFile File { get; set; }
    }
}
