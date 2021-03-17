using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchülerHelfenSchüler.Models;

namespace SchülerHelfenSchüler.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase {

        private SchülerHelfenSchülerContext context;

        public UserController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll() {
            return context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(string id) {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();
            User user;
            user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user == null)
                return NotFound();
            else
                return user;
        }

        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user) {
            if (context.Users.Where(x => x.Id == user.Id).Count() > 0) 
                context.Users.Update(user);
            else
                context.Users.Add(user);
            try {
                context.SaveChanges();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
            return user;
        }
    }
}
