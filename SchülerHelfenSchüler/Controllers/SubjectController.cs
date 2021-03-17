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
    public class SubjectController : ControllerBase
    {
        private SchülerHelfenSchülerContext context;

        public SubjectController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetAll() {
            List<string> result = new List<string>();
            foreach (var subject in context.Subjects) {
                result.Add(subject.Subject1);
            }
            return result;
        }
    }
}