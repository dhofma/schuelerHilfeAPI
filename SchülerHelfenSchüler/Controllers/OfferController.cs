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
        public ActionResult<Offer> CreateOffer([FromBody] Offer offer) {
            if (context.Offers.Where(x => x.UserId == offer.UserId && x.Subject == offer.Subject).Count() > 0) {
                Offer tempOffer = context.Offers.Where(x => x.UserId == offer.UserId && x.Subject == offer.Subject).First();
                tempOffer.TeacherId = offer.TeacherId;
                context.Offers.Update(tempOffer);
            }   
            else {
                context.Offers.Add(new Offer() {
                    UserId = offer.UserId,
                    Subject = offer.Subject,
                    TeacherId = offer.TeacherId
                });
            }
            try {
                context.SaveChanges();
            }
            catch (Exception ex) {
                return BadRequest(ex);
            }
            return offer;
        }


    }
}