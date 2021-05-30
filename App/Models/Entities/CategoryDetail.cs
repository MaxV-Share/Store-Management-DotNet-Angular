using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class CategoryDetail : BaseEntity
    {
        public Category Category { get; set; }
        public Lang Lang{ get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
