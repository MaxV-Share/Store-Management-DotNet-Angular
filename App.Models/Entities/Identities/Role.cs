using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace App.Models.Entities.Identities
{
    public class Role : IdentityRole
    {
        public virtual ICollection<UserRole> UserRoles { get; }
        public virtual ICollection<RoleClaim> RoleClaims { get; }
    }
}
