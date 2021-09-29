using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Lang : BaseEntity<string>
    {
        public override Lang SetDefaultValue(string createBy)
        {
            CreateAt = DateTime.Now;
            UpdateAt = CreateAt;
            return this;
        }
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
