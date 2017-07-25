using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Internationalization.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public int? CurrencyId { get; set; }

        public string Culture { get; set; }

        public ICollection<Donation> Donations { get; set; }

        public ApplicationUser()
        {
            Donations = new HashSet<Donation>();
        }
    }
}
