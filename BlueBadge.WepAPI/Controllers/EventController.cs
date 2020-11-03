using BlueBadge.Models.Event;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BlueBadge.WepAPI.Controllers
{
    [Authorize]
    public class EventController : ApiController
    {
        private EventService CreateEventService(int venueId)
        {
            var eventService = new EventService(venueId);
            return eventService;
        }

        // Create
        public IHttpActionResult Post(EventCreate newEvent, [FromUri] int venueId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventService = CreateEventService(venueId);

            if (!eventService.CreateEvent(newEvent))
                return InternalServerError();

            return Ok(newEvent);
        }

        // Read
        // Update 
        // Delete
    }
}