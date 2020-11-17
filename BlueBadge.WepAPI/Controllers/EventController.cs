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
        public IHttpActionResult GetAllEvents()
        {
            var eventService = CreateEventService();
            var events = eventService.GetAllEvents();
            return Ok(events);
        }

        // Get Upcoming
        [Route("upcoming")]
        public IHttpActionResult Get()
        {
            EventService eventService = CreateEventService();
            var events = eventService.GetUpcomingEvents();
            return Ok(events);
        }

        // Get by Venue/Event Id
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
                    return BadRequest("The request is invalid, please specify your search parameters. (Try \"e\" or \"v\" for {type})");
            }
        }

        // Get by Date
        [Route("date/{date}")]
        public IHttpActionResult Get(DateTime date)
        {
            var eventService = CreateEventService();
            var events = eventService.GetEventsByDate(date);
            return Ok(events);
        }

        // Update 
        public IHttpActionResult Put(EventEdit updatedEvent)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var eventService = CreateEventService();

            if (!eventService.UpdateEvent(updatedEvent))
                return InternalServerError();

            return Ok();
        }

        // Delete
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            var eventService = CreateEventService();

            if (!eventService.DeleteEvent(id))
                return InternalServerError();
            
            return Ok();
        }
    }
}