using MaxV.Common.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxV.Common.Model
{
    public class SortDescriptor
    {
        public string Field { get; set; }
        public SortDirection Direction { get; set; }
    }
}
