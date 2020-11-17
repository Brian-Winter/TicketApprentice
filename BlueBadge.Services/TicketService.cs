using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueBadge.Data;
using BlueBadge.Models;
using BlueBadge.Models.TicketModels;
using BlueBadge.Models.Event;

namespace BlueBadge.Services
{
    public class TicketService
    {
        private EventService _listofEvents = new EventService();
        private readonly Guid _userId;
        public TicketService() { }
       
        public TicketService(Guid userId)
        {
            _userId = userId;
        }
        //Create
        public bool TicketCreate(TicketCreate model)
        {
            //option one on ticket cost with demand and tier
            switch (model.TicketDemand)
            {
                case DemandOfEventTicketScale.low:
                    switch (model.TierOfTicket)
                    {
                        case TicketTier.General:
                            model.Cost = 15.00m;
                            break;
                        case TicketTier.LowerLevel:
                            model.Cost = 30.00m;
                            break;
                        case TicketTier.VIP:
                            model.Cost = 60.00m;
                            break;
                    }
                    break; 
                case DemandOfEventTicketScale.medium:
                    switch (model.TierOfTicket)
                    {
                        case TicketTier.General:
                            model.Cost = 30.00m;
                            break;
                        case TicketTier.LowerLevel:
                            model.Cost = 60.00m;
                            break;
                        case TicketTier.VIP:
                            model.Cost = 120.00m;
                            break;
                    }
                    break; 
                case DemandOfEventTicketScale.high:
                    switch (model.TierOfTicket)
                    {
                        case TicketTier.General:
                            model.Cost = 50.00m;
                            break;
                        case TicketTier.LowerLevel:
                            model.Cost = 100.00m;
                            break;
                        case TicketTier.VIP:
                            model.Cost = 200.00m;
                            break;
                    }
                    break;  
                case DemandOfEventTicketScale.extreme:
                    switch (model.TierOfTicket)
                    {
                        case TicketTier.General:
                            model.Cost = 100.00m;
                            break;
                        case TicketTier.LowerLevel:
                            model.Cost = 150.00m;
                            break;
                        case TicketTier.VIP:
                            model.Cost = 300.00m;
                            break;
                    }
                    break;
            }

            //Option Two on equation for Cost
            //need to convert to number
         //  model.Cost = (model.TicketDemand.ToI + model.TierOfTicket) * 30
            var entity = 
                new Ticket()
                {
                    TierOfTicket = model.TierOfTicket,
                    Cost = model.Cost,
                    SeatName = model.SeatName,
                    EventId = model.EventId,
                    UserId = _userId
                };

            
            _listofEvents.UpdateEventbyTicketSold(model.EventId);
            

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
                var query = 
                    ctx
                    .Ticket
                    .Select(
                        e => new TicketListItem
                        {
                            TicketId = e.TicketId,
                            EventId = e.EventId,
                            Cost = e.Cost,
                            SeatName = e.SeatName,
                            UserId = e.UserId
                          
                        }
                              
                    );
                return query.ToArray();
            
            }
        }
     //   View By User

                    
         public IEnumerable<TicketDetails> GetTicketByUserId(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ticket
                    .Where(e => e.UserId == id)
                    .Select(
                        e => new TicketDetails
                        {
                            Cost = e.Cost,
                            EventId = e.EventId,
                            SeatName = e.SeatName

                        }

                    );
                return query.ToArray();

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
       // View by Event
        public IEnumerable<TicketListItem> GetTicketByEventId(int eventId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Ticket
                    .Where(e => e.EventId == eventId) 
                    .Select(
                        e => new TicketListItem
                        {
                            TicketId = e.TicketId,
                            EventId = e.EventId,
                            Cost = e.Cost,
                            SeatName = e.SeatName
                        }

                    );
                return query.ToArray();

            }
        }
        //Update Ticket 

        public bool UpdateTicket(TicketEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                        ctx
                            .Ticket
                            .Single(e => e.TicketId == model.TicketId);

                entity.Cost = model.Cost;
                entity.SeatName = model.SeatName;

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
