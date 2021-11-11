using MaxV.Base.DTOs;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs.UpdateRquests
{
    public class CommandUpdateRequest : BaseUpdateRequest<string>
    {
        [Required]
        public string Name { get; set; }
    }
}
