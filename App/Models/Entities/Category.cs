using MaxV.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class Category : BaseEntity<int>
    {
        public override void SetValueUpdate()
        {
            base.SetValueUpdate();
            CategoryDetails.ToList().ForEach(e =>
            {
                e.CreateBy = CreateBy;
                e.SetValueUpdate();
            });
        }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<CategoryDetail> CategoryDetails { get; set; }
    }
}
