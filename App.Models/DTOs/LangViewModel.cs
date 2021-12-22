using System.ComponentModel.DataAnnotations;
using MaxV.Common.Model.DTOs;

namespace App.Models.DTOs
{
    public class LangViewModel : BaseViewModel<string>
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
