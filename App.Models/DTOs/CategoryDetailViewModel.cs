using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.DTOs
{
    public class CategoryDetailViewModel : BaseViewModel<int>
    {
        public int CategoryId { get; set; }
        public string LangId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
