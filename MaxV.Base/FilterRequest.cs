using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Model;

namespace App.Common.Model
{
    public class FilterRequest
    {
        public FilterLogicalOperator LogicalOperator { get; set; }
        public IEnumerable<FilterDetailsRequest> Details { get; set; }
    }
}
