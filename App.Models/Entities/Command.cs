using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Common.Model;

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
        public virtual ICollection<CommandDetail> CommandDetail { get; set; }
        public virtual ICollection<CommandInFunction> CommandInFunctions { get; set; }
    }
}
