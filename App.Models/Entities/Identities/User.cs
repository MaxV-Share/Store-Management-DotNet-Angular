using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace App.Models.Entities.Identities
{
    public class User : IdentityUser
    {
        public string FullName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; }
        public virtual ICollection<UserClaim> UserClaims { get; }
    }
}
