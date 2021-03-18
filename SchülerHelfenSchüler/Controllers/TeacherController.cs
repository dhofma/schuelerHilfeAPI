using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchülerHelfenSchüler.Models;

namespace SchülerHelfenSchüler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private SchülerHelfenSchülerContext context;

        public TeacherController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Teacher>> GetAll() {
            return context.Teachers.ToList();
        }

        [HttpGet("{subject}")]
        public ActionResult<IEnumerable<Teacher>> GetTeacherBySubject(string subject) {
            return context.SubjectTeachers.Where(x => x.Subject == subject).Select(x => x.Teacher).ToList();
        }
    }
}