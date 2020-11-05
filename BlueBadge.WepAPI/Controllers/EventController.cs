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
    [RoutePrefix("api/Event")]
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

        [Route("{type}/{id}")]
        public IHttpActionResult Get(string type, int id)
        {
            var eventService = CreateEventService();

            switch (type)
            {
                case "e":
                    var e = eventService.GetEventById(id);
                    return Ok(e);
                    
                case "v":
                    var ev = eventService.GetEventsByVenue(id);
                    return Ok(ev);

                default:
                    return BadRequest("The request is invalid, please specify your search parameters. (Try \"event\" or \"venue\")");
            }
        }

        [Route("date")]
        public IHttpActionResult Get([FromBody] DateTime date)
        {
            var eventService = CreateEventService();
            var events = eventService.GetEventsByDate(date);
            return Ok(events);
        }

        // Update 
        // Delete
    }
}