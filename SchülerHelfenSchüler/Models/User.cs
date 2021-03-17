using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class User
    {
        public User()
        {
            Offers = new HashSet<Offer>();
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }

        public virtual Class ClassNavigation { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
    }
}
