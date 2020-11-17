using BlueBadge.Data;
using BlueBadge.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlueBadge.Services
{
    //[RoutePrefix("api/venue")]
    public class VenueService
    {
        //private readonly Guid _userId;

        //public VenueService(Guid userId)
        //{
        //    _userId = userId;
        //}

        //Create Venue
        public bool CreateVenue(VenueCreate model)
        {
            if(model.Capacity < model.NumberOfSeats)
            {
                
                return false;
            }
            var entity =
                new Venue()
                {
                    VenueId = model.VenueId,
                    VenueName = model.VenueName,
                    StreetAddress = model.StreetAddress,
                    City = model.City,
                    State = model.State,
                    Capacity = model.Capacity,
                    NumberOfSeats = model.NumberOfSeats,
                };

           
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Venue.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //See All Venues
        public IEnumerable<VenueListItem> GetVenues()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Venue
                        //.Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new VenueListItem
                                {
                                    VenueId = e.VenueId,
                                    VenueName = e.VenueName,
                                    StreetAddress = e.StreetAddress,
                                    City = e.City,
                                    State = e.State,
                                    Capacity = e.Capacity,
                                    NumberOfSeats = e.NumberOfSeats


                                }
                        );

                return query.ToArray();
            }
        }

        //Edit Venue

        public bool UpdateVenue(VenueEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venue
                        .Single(e => e.VenueId == model.VenueId /*&& e.OwnerId == _userId*/);


                entity.VenueId = model.VenueId;
                entity.VenueName = model.VenueName;
                entity.StreetAddress = model.StreetAddress;
                entity.City = model.City;
                entity.State = model.State;
                entity.Capacity = model.Capacity;
                entity.NumberOfSeats = model.NumberOfSeats;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Venue

        public bool DeleteVenue(int venueId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Venue
                        .Single(e => e.VenueId == venueId);

                ctx.Venue.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        //See Single Venue by Id

        public VenueDetail GetVenueById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Venue.Single(e => e.VenueId == id);
                return
                    new VenueDetail
                    {
                        VenueId = entity.VenueId,
                        VenueName = entity.VenueName,
                        StreetAddress = entity.StreetAddress,
                        City = entity.City,
                        State = entity.State,
                        Capacity = entity.Capacity,
                        NumberOfSeats = entity.NumberOfSeats
                    };
            }
        }

        //See Venues by State (add a Route /States)


        public IEnumerable<VenueListItem> GetVenueByState(string state)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Venue
                        .Where(e => e.State == state)
                        .Select(
                            e =>
                                new VenueListItem
                                {
                                    VenueId = e.VenueId,
                                    VenueName = e.VenueName,
                                    State = e.State,
                                    StreetAddress = e.StreetAddress,
                                    City = e.City,
                                    Capacity = e.Capacity,
                                    NumberOfSeats = e.NumberOfSeats
                                }
                        );

                return query.ToArray();
            }
        }



    }
}
