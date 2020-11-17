using BlueBadge.Data;
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

        public IHttpActionResult Get()
        {
            VenueService venueService = CreateVenueService();
            var venue = venueService.GetVenues();
            return Ok(venue);
        }

        public IHttpActionResult Post(VenueCreate venue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venueService = CreateVenueService();

            if (!venueService.CreateVenue(venue))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Get(int id)
        {
            VenueService venueService = CreateVenueService();
            var venue = venueService.GetVenueById(id);
            return Ok(venue);
        }

        public IHttpActionResult Put(VenueEdit venue)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateVenueService();

            if (!service.UpdateVenue(venue))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateVenueService();

            if (!service.DeleteVenue(id))
                return InternalServerError();

            return Ok();
        }

        [Route("api/Venue/state/{state}")]
        public IHttpActionResult Get(string state)
        {
            VenueService venueService = CreateVenueService();
            var venue = venueService.GetVenueByState(state);
            return Ok(venue);
        }

        private VenueService CreateVenueService()
        {
            var venueService = new VenueService();
            return venueService;
        }
    }
}
