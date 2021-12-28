using System;
using System.Collections.Generic;
using System.Text;
using App.Common.Model.Enums;

namespace App.Common.Model
{
    public class FilterDetailsRequest
    {
        public string AttributeName { get; set; }
        public string Value { get; set; }
        public FilterType FilterType { get; set; }
    }
}
