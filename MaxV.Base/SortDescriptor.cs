using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Common.Model.Enums;

namespace App.Common.Model
{
    public class SortDescriptor
    {
        public string Field { get; set; }
        public SortDirection Direction { get; set; }
    }
}
