using System.ComponentModel.DataAnnotations;
using App.Models.DTOs;
using App.Common.Model.DTOs;

namespace App.Models.DTOs.Langs
{
    public class LangViewModel : BaseViewModel<string>
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
