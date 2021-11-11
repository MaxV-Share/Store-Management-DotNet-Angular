using Microsoft.AspNetCore.Identity;

namespace App.Models.Entities.Identities
{
    public class RoleClaim : IdentityRoleClaim<string>
    {
        public virtual Role Role { get; set; }
    }
}
