using BlueBadge.Models.TicketModels;
using BlueBadge.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BlueBadge.WepAPI.Controllers
{
    [Authorize]
    public class TicketController : ApiController
    {
        private TicketService CreateTicketService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var ticketService = new TicketService(userId);
            return ticketService;
        }
        //POST
        public IHttpActionResult Post(TicketCreate ticket)
        {
            if (!ModelState.IsValid)

                return BadRequest(ModelState);

            var service = CreateTicketService();
            if (!service.TicketCreate(ticket))

                return InternalServerError();


            return Ok(ticket);

        }
        //PUT Change Cost/Seat
        public IHttpActionResult Put(TicketEdit ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTicketService();

            if (!service.UpdateTicket(ticket))
                return InternalServerError();

            return Ok();
        }

        //PUT UserID 

        //PUT Remove  User ID
       // [Route("api/Ticket/Refund")]
        //GET ALL
        public IHttpActionResult Get()
        {
            TicketService ticketService = CreateTicketService();
            var tickets = ticketService.GetTicketList();
            return Ok(tickets);

        }
        //GET USER ID
        [Route("api/Ticket/User/{id}")]
        public IHttpActionResult GetByUserId(Guid id)
        {
            TicketService ticketService = CreateTicketService();
            var ticket = ticketService.GetTicketByUserId(id);
            return Ok(ticket);
        }
        //GET EVENT ID
        [Route("api/Ticket/Event/{id}")]
        public IHttpActionResult GetByEventId(int id)
        {
            TicketService ticketService = CreateTicketService();
            var ticket = ticketService.GetTicketByEventId(id);
            return Ok(ticket);
        }
        //GET TICKET ID

        public IHttpActionResult GetByTicketId(int id)
        {
            TicketService ticketService = CreateTicketService();
            var ticket = ticketService.GetTicketByTicketId(id);
            return Ok(ticket);
        }
        //DELETE TICKET ID
        public IHttpActionResult DeleteTicket(int id)
        {
            var service = CreateTicketService();
            if (!service.RemoveTicket(id))
            {
                return InternalServerError();
            }
            return Ok();
        }
    }
}
