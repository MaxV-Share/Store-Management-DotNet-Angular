using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs.Paging
{
    public class BasePaging<T>
    {
        public int TotalRow { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
