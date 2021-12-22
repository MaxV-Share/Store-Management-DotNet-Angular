using MaxV.Base.DTOs;
using System.ComponentModel.DataAnnotations;

namespace App.Models.DTOs
{
    public class LangViewModel : BaseViewModel<string>
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
