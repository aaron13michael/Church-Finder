using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Church_Finder.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public List<int> Locations { get; }

    }
}
