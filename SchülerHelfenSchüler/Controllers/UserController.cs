using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchülerHelfenSchüler.Models;

namespace SchülerHelfenSchüler.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase {

        [HttpGet]
        public IEnumerable<User> Get() {
            using (var context = new SchülerHelfenSchülerContext()) {
                return context.Users.ToList();
            }
        }
    }
}
