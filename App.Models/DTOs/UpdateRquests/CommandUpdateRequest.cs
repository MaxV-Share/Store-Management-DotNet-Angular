using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs.UpdateRquests
{
    public class CommandUpdateRequest : BaseUpdateRequest<string>
    {
        [Required]
        public string Name { get; set; }
    }
}
