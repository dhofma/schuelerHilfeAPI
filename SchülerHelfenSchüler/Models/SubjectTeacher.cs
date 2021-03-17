using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class SubjectTeacher
    {
        public int TeacherId { get; set; }
        public string Subject { get; set; }

        public virtual Subject SubjectNavigation { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
