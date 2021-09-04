using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using SchülerHelfenSchüler.Models;

namespace SchülerHelfenSchüler.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private SchülerHelfenSchülerContext context;

        public MailController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        public ActionResult SendMail([FromBody] RequestMessage message) {
            string fromAdress = context.Users.Where(x => x.Id == message.FromId).First().Email;
            string toAdress = context.Users.Where(x => x.Id == message.ToId).First().Email;

            //Delete once tested
            toAdress = "20152081@atn.ac.at";

            MailMessage mailMessage = new MailMessage(fromAdress, toAdress, message.Subject, message.Body);



            return BadRequest();
        }
    }
}