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
    public class OfferController : ControllerBase {
        private SchülerHelfenSchülerContext context;

        public OfferController(SchülerHelfenSchülerContext context) {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserOffer>> GetAll() {
            return context.UserOffers.ToList();
        }

        [HttpPost("{filter}")]
        public ActionResult<IEnumerable<UserOffer>> GetOffersByFilter([FromBody] OfferFilter filter) {
            List<UserOffer> result = context.UserOffers.ToList();
            if (!string.IsNullOrWhiteSpace(filter.UserId)) {
                result = result.Where(x => x.UserId == filter.UserId).ToList();
            }
            if (!string.IsNullOrWhiteSpace(filter.Subject)) {
                result = result.Where(x => x.Subject == filter.Subject).ToList();
            }
            if (filter.TeacherId != 0) {
                result = result.Where(x => x.TeacherId == filter.TeacherId).ToList();
            }
            return result;
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

        [HttpDelete]
        public ActionResult Delete([FromBody] UserOffer uoffer) {
            Offer toDelete = context.Offers.Where(x => x.UserId == uoffer.UserId && x.Subject == uoffer.Subject && x.TeacherId == uoffer.TeacherId).First();
            context.Offers.Remove(toDelete);
            context.SaveChanges();
            return Ok();
        }


    }
}