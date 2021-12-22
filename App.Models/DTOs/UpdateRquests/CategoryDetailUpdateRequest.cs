using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class CategoryDetailUpdateRequest : BaseUpdateRequest<int>
    {
        public int CategoryId { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
