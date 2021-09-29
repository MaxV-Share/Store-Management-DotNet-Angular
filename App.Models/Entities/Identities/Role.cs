using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities.Identities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; }
        public virtual ICollection<RoleClaim> RoleClaims { get; }
    }
}
