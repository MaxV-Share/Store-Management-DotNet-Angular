﻿using MaxV.Base.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DTO
{
    public class UserCreateRequest : BaseDTOCreateRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RoleId { get; set; } 
    }
}
