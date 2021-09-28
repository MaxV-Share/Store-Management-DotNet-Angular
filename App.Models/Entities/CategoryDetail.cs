using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class CategoryDetail : BaseEntity<int>
    {
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual Lang Lang { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
