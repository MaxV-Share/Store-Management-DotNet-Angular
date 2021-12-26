using MaxV.Common.Model.DTOs;
using App.Models.DTOs.UpdateRquests;

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
