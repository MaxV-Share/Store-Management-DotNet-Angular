using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.Imports
{
    public class ProductImport
    {
        public IFormFile File { get; set; }
    }
}
