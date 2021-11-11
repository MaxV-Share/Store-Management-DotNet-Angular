using MaxV.Base.DTOs;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs.UpdateRquests
{
    public class LangUpdateRequest : BaseUpdateRequest<string>
    {
        [MaxLength(10)]
        public override string Id { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
