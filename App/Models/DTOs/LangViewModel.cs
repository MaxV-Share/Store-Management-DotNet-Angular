using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class LangViewModel : BaseViewModel<string>
    {
        [MaxLength(20)]
        public string Name { get; set; }
        public int Order { get; set; }
    }
}
