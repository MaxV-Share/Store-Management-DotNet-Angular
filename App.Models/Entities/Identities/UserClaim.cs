using Microsoft.AspNetCore.Identity;

namespace App.Models.Entities.Identities
{
    public class UserClaim : IdentityUserClaim<string>
    {
        public virtual User User { get; set; }
    }
}
