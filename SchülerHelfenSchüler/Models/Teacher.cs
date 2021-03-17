using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Offers = new HashSet<Offer>();
            SubjectTeachers = new HashSet<SubjectTeacher>();
        }

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<SubjectTeacher> SubjectTeachers { get; set; }
    }
}
