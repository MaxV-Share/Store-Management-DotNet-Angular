using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class CommandViewModel : BaseViewModel<string>
    {
        [MaxLength(50)]
        public override string Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
