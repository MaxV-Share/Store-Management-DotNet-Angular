using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxV.Common.Model.Enums;

namespace MaxV.Common.Model
{
    public class RequestOrder
    {
        public string OrderBy { get; set; }
        public SortBy? SortBy { get; set; }
    }
}
