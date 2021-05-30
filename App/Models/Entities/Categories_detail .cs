using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Categories_detail
    {
        [MaxLength(10,ErrorMessage ="")]
        public Category Parent { get; set; }
        public Lang langiId{ get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Description")]
        public string Description { get; set; }
    }
}
