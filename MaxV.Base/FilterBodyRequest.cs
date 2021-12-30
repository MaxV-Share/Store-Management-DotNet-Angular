using System;
using System.Collections.Generic;
using System.Text;
using App.Common.Model;

namespace App.Common.Model
{
    public class FilterBodyRequest : BodyRequest
    {
        public string LangId { get; set; }
        public string SearchValue { get; set; }
        public FilterRequest Filter { get; set; }
        public IEnumerable<SortDescriptor> Orders { get; set; }
        public Pagination Pagination { get; set; }
    }
}
