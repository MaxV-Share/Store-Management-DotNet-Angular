using System;
using System.Collections.Generic;
using System.Text;
using MaxV.Common.Model;

namespace MaxV.Common.Model
{
    public class RequestFilterBody : RequestBody
    {
        public string SearchValue { get; set; }
        public RequestFilter Filter { get; set; }
        public IEnumerable<SortDescriptor> Orders { get; set; }
        public Pagination Pagination { get; set; }
    }
}
