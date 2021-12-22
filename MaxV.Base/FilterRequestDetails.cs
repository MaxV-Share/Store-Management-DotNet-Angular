using System;
using System.Collections.Generic;
using System.Text;
using MaxV.Common.Model.Enums;

namespace MaxV.Common.Model
{
    public class FilterRequestDetails
    {
        public string AttributeName { get; set; }
        public string Value { get; set; }
        public FilterType FilterType { get; set; }
    }
}
