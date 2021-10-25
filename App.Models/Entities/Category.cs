using MaxV.Base;
using System.Collections.Generic;
using System.Linq;

namespace App.Models.Entities
{
    public class Category : BaseEntity<int>
    {
        public override Category SetValueUpdate(string updateAt)
        {
            base.SetValueUpdate(updateAt);
            CategoryDetails.ToList().ForEach(e =>
            {
                e.CreateBy = CreateBy;
                e.SetValueUpdate(updateAt);
            });
            return this;
        }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<CategoryDetail> CategoryDetails { get; set; }
    }
}
