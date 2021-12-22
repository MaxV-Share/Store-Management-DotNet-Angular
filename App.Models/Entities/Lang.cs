using System;
using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model;

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
