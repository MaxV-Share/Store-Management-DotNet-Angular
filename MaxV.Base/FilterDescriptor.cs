using MaxV.Common.Model.Enums;
using MaxV.Common.Model;

namespace MaxV.Common.Model
{
    public class FilterDescriptor
    {
        public string Field { get; set; }
        public string[] Values { get; set; }
        public FilterType Operator { get; set; }
        public FilterLogicalOperator LogicalOperator { get; set; }
    }
}
