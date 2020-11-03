using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.TicketModels;

namespace BlueBadge.Services
{
    public class TicketService
    {
        private Ticket _listOfTicket = new Ticket();
        private readonly Guid _userId;
        public TicketService() { }
        public TicketService(int ticketID)
        {
            _listOfTicket.TicketId = ticketID;
        }
        public TicketService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        public bool TicketCreate(TicketCreate model)
        {
            var entity = new Ticket()
            {
               
                Cost = model.Cost,
                SeatName = model.SeatName,
                EventId = model.EventId,
                UserId = model.UserId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Ticket.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        //Delete
        public bool RemoveTicket(int ticketId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                                .Ticket
                                .Single(e => e.TicketId == ticketId);

                ctx.Ticket.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        //View ALL
        public IEnumerable<TicketListItem> GetTicketList()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query = ctx.Ticket
                    .Where(e => e.TicketId == _listOfTicket.TicketId)
                    .Select(
                        e => new TicketListItem
                        {
                            TicketId = e.TicketId,
                            EventId = e.EventId,
                            SeatName = e.SeatName
                        }
                              
                    );
                return query.ToArray();
            
            }
        }
        //View By User
        public TicketDetails GetTicketByUserId(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ticket.Single(e => e.UserId == _userId);
                return new TicketDetails
                {
                    Cost = entity.Cost,
                    EventId = entity.EventId,
                    SeatName = entity.SeatName
                };


            }



        }
        //View by TicketID
        public TicketDetails GetTicketByTicketId(int id)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ticket.Single(e => e.TicketId == id);
                return new TicketDetails
                {
                    Cost = entity.Cost,
                    EventId = entity.EventId,
                    SeatName = entity.SeatName
                };


            }



        }
        //View by Event
        public TicketDetails GetTicketByEventId(int eventId)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Ticket.Single(e => e.EventId == eventId);
                return new TicketDetails
                {
                    TicketId = entity.TicketId,
                    Cost = entity.Cost,
                    EventId = entity.EventId,
                    SeatName = entity.SeatName
                };


            }



        }
    }
}
