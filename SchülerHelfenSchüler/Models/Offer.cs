using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class Offer
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int TeacherId { get; set; }
        public string UserId { get; set; }

        public virtual Subject SubjectNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual User User { get; set; }
    }
}
