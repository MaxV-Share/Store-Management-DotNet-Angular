using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxV.Common.Model
{
    public class Pagination
    {
        public Pagination()
        {
            PageIndex = 1;
            PageSize = 10;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
