using App.Common.Model;

namespace App.Models.Entities
{
    public class CategoryDetail : BaseEntity<int>
    {
        public int CategoryId { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Lang Lang { get; set; }
        public virtual Category Category { get; set; }
    }
}
