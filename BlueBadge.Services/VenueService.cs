using BlueBadge.Data;
using BlueBadge.Models.Venue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Services
{
    public class VenueService
    {
        //private readonly Guid _userId;

        //public VenueService(Guid userId)
        //{
        //    _userId = userId;
        //}

        public bool CreateVenue(VenueCreate model)
        {
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


    }
}
