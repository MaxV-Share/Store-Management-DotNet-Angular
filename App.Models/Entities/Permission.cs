using App.Models.Entities.Identities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MaxV.Common.Model;

namespace App.Models.Entities
{
    public class Permission : BaseEntity<Guid>
    {
        public Permission()
        {
        }
        public Permission(string functionId, string roleId, string commandId)
        {
            FunctionId = functionId;
            RoleId = roleId;
            CommandId = commandId;
        }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string FunctionId { get; set; }
        public virtual Function Function { get; set; }
        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string RoleId { get; set; }
        public virtual UserRole Role { get; set; }

        [MaxLength(50)]
        [Column(TypeName = "varchar(50)")]
        public string CommandId { get; set; }
        public virtual Command Command { get; set; }
    }
}
