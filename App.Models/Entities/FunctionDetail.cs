﻿using App.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models.Entities
{
    public class FunctionDetail : BaseEntity<int>
    {
        public string LangId { get; set; }
        public string Name { get; set; }
        public string FunctionId { get; set; }
        public virtual Lang Lang { get; set; }
        public virtual Function Function { get; set; }
    }
}
