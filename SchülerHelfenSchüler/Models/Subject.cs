using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Offers = new HashSet<Offer>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

        public string Subject1 { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
