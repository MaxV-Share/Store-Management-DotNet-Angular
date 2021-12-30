using App.Models.DTOs.UpdateRquests;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.CategoryDetails
{
    public class CategoryDetailUpdateRequest : BaseUpdateRequest<int>
    {
        public int CategoryId { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
