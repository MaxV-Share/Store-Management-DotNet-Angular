using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Common.Model;

namespace App.Models.Entities
{
    public class Function : BaseEntity<string>
    {
        [Key]
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public override string Id { get; set; }
        public virtual ICollection<FunctionDetail> Detail { get; set; }
        [MaxLength(200)]
        [Required]
        public string Url { get; set; }
        [Required]
        public int SortOrder { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string ParentId { get; set; }
        public virtual Function Parent { get; set; }
        public virtual ICollection<Function> Childrens { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string Icon { get; set; }
        public virtual ICollection<CommandInFunction> CommandInFunctions { get; set; }
    }
}
