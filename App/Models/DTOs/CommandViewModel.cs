using MaxV.Base.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
