using BlueBadge.Models.Venue;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BlueBadge.WepAPI.Controllers
{
    [Authorize]
    public class VenueController : ApiController
    {
        
        public IHttpActionResult Post(VenueCreate venue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venueService = CreateVenueService();

            if (!venueService.CreateVenue(venue))
                return InternalServerError();

            return Ok();
        }

        private VenueService CreateVenueService()
        {
            var venueService = new VenueService();
            return venueService;
        }
    }
}
