using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaxV.Common.Model;

namespace MaxV.Common.Model
{
    public class RequestFilter
    {
        public FilterLogicalOperator LogicalOperator { get; set; }
        public IEnumerable<RequestFilterDetails> Details { get; set; }
    }
}
