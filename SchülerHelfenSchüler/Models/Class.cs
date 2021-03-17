using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class Class
    {
        public Class()
        {
            Users = new HashSet<User>();
        }

        public string Class1 { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
