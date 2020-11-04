using BlueBadge.Data;
using BlueBadge.Models.Event;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BlueBadge.Services
{
    public class EventService
    {
        // Create
        public bool CreateEvent(EventCreate model)
        {
            Event newEvent = new Event()
            {
                VenueId = model.VenueId,
                Date = model.Date,
                EventName = model.EventName,
                MaxTickets = model.MaxTickets,
                AvailableTickets = model.AvailableTickets,
                ExpectedRevenue = model.ExpectedRevenue
            };

            using (ApplicationDbContext ctx = new ApplicationDbContext())
            {
                ctx.Events.Add(newEvent);
                return ctx.SaveChanges() == 1;
            }
        }

        // Read
        public IEnumerable<EventListItem> GetAllEvents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.Date > DateTime.Now)
                        .Select(
                            e =>
                                new EventListItem
                                {
                                    EventId = e.EventId,
                                    Date = e.Date,
                                    EventName = e.EventName
                                }
                            );
                return query.ToArray();
            }
        }
            // view by id
            // view all by venue
            // view all by date

        // Update
            // put

        // Delete
            // delete
    }
}
