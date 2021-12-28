using App.Common.Model.Enums;
using App.Common.Model;

namespace App.Common.Model
{
    public class FilterDescriptor
    {
        public string Field { get; set; }
        public string[] Values { get; set; }
        public FilterType Operator { get; set; }
        public FilterLogicalOperator LogicalOperator { get; set; }
    }
}
