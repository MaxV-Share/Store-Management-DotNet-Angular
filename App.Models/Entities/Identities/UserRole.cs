﻿using Microsoft.AspNetCore.Identity;

namespace App.Models.Entities.Identities
{
    public class UserRole : IdentityUserRole<string>
    {
        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

    }
}
