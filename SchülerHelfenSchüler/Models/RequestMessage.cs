using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchülerHelfenSchüler.Models {
    public class RequestMessage {
        public string Body { get; set; }
        public string FromId { get; set; }
        public string ToId { get; set; }
        public string Subject { get; set; }
    }
}
