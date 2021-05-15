using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class ProductRequest
    {
        public int CategoryId{ get; set; }
        public string Name { get; set; }
    }
}
