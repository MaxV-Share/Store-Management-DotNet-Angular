using System.ComponentModel.DataAnnotations;
using App.Common.Model;

namespace App.Models.Entities
{
    public class ProductDetail : BaseEntity<int>
    {
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
        public virtual Lang Lang { get; set; }
        public string LangId { get; set; }
        [MaxLength(256)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
