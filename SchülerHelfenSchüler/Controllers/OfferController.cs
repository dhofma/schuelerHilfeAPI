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
    public class OfferController : ControllerBase
    {
        private SchülerHelfenSchülerContext context;

        public OfferController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserOffer>> GetAll() {
            return context.UserOffers.ToList();
        }

        [HttpGet("{userId}")]
        public ActionResult<IEnumerable<UserOffer>> GetOffersByUser(string userId) {
            return context.UserOffers.Where(x => x.UserId == userId).ToList();
        }

        [HttpPost]
        public ActionResult CreateOffer([FromBody] UserOffer uOffer) {
            if (context.Offers.Where(x => x.UserId == uOffer.UserId && x.Subject == uOffer.Subject).Count() > 0) {
                context.Offers.Update(new Offer() {
                    UserId = uOffer.UserId,
                    Subject = uOffer.Subject,
                    TeacherId = uOffer.TeacherId
                });
            }
            else {
                context.Offers.Add(new Offer() {
                    UserId = uOffer.UserId,
                    Subject = uOffer.Subject,
                    TeacherId = uOffer.TeacherId
                });
            }
            try {
                context.SaveChanges();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
            return Ok();
        }


    }
}