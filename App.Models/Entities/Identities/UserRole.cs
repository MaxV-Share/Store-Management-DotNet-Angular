using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Models.Entities.Identities
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

    }
}
