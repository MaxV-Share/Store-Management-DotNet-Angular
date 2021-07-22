using App.DTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities.Identities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; }
        public virtual ICollection<UserClaim> UserClaims { get; }
    }
}
