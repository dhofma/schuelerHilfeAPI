using System;
using System.Collections.Generic;

#nullable disable

namespace SchülerHelfenSchüler.Models
{
    public partial class UserOffer
    {
        public string UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string Class { get; set; }
        public int TeacherId { get; set; }
        public string TeacherFirstName { get; set; }
        public string TeacherLastName { get; set; }
        public string Subject { get; set; }
    }
}
