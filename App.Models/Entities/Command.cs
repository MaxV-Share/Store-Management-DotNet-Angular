using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MaxV.Base;

namespace App.Models.Entities
{
    public class Command : BaseEntity<string>
    {
        public override Command SetDefaultValue(string createBy)
        {
            CreateAt = DateTime.Now;
            UpdateAt = CreateAt;
            return this;
        }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Key]
        public override string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public virtual ICollection<CommandInFunction> CommandInFunctions { get; set; }
    }
}
