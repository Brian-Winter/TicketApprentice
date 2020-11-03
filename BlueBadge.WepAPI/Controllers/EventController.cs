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
        private EventService CreateEventService()
        {
            var eventService = new EventService();
            return eventService;
        }

        // Create
        public IHttpActionResult Post(EventCreate newEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventService = CreateEventService();

            if (!eventService.CreateEvent(newEvent))
                return InternalServerError();

            return Ok(newEvent);
        }

        // Read
        // Get All
        public IHttpActionResult Get()
        {
            EventService eventService = CreateEventService();
            var events = eventService.GetAllEvents();
            return Ok(events);
        }

        // Update 
        // Delete
    }
}