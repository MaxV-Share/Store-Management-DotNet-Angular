using MaxV.Common.Model;

namespace App.Models.Entities
{
    public class CategoryDetail : BaseEntity<int>
    {
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual Lang Lang { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
