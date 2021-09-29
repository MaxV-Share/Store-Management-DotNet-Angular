using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class RoleViewModel : BaseViewModel<string>
    {
        public string Name { get; set; }
    }
}
