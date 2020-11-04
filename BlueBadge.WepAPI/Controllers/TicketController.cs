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
        public TicketService CreateTicketService()
        {
            var ticketService = new TicketService();
            return ticketService;
        }
        public IHttpActionResult Post(TicketCreate ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var service = CreateTicketService();
            if (!service.TicketCreate(ticket))
            
                return InternalServerError();
            

            return Ok();

        }
    }
}
