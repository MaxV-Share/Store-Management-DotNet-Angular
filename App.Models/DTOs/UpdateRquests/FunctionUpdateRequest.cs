using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class FunctionUpdateRequest : BaseUpdateRequest<string>
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int SortOrder { get; set; }
        public string ParentId { get; set; }
        public string Icon { get; set; }
    }
}
