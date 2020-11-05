﻿using BlueBadge.Data;
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
                        .Where(e => e.Date >= DateTime.Now)
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

        public EventDetail GetEventById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Events
                        .Single(e => e.EventId == id);
                return
                    new EventDetail
                    {
                        EventId = entity.EventId,
                        Date = entity.Date,
                        EventName = entity.EventName,
                        MaxTickets = entity.MaxTickets,
                        AvailableTickets = entity.AvailableTickets,
                        ExpectedRevenue = entity.ExpectedRevenue
                    };
            }
        }

        public IEnumerable<EventListItem> GetEventsByVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.VenueId == venueId)
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

        public IEnumerable<EventListItem> GetEventsByDate(DateTime date)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Events
                        .Where(e => e.Date == date)
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

        // Update
        // put

        // Delete
        // delete
    }
}
