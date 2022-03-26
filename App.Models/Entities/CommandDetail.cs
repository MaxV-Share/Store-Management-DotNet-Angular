using App.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class CommandDetail : BaseEntity<int>
    {
        public string LangId { get; set; }
        public string Name { get; set; }
        public virtual Lang Lang { get; set; }
        public virtual Command Command { get; set; }
    }
}
