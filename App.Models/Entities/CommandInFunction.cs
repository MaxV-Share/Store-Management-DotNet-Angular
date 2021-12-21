using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaxV.Common.Model;

namespace App.Models.Entities
{
    public class CommandInFunction : BaseEntity<Guid>
    {
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string CommandId { get; set; }
        public virtual Command Command { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        [Required]
        public string FunctionId { get; set; }
        public virtual Function Function { get; set; }
    }
}
