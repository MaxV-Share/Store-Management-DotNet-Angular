using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;
using App.Models.DTOs.UpdateRquests;

namespace App.Models.DTOs.Langs
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
