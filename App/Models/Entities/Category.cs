using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual List<CategoryDetail> CategoryDetails { get; set; }
    }
}
