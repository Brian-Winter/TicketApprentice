using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Venue
{
    public class VenueListItem
    {
        public int VenueId { get; set; }
        public string VenueName { get; set; }
        public string State { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public int Capacity { get; set; }
        public int NumberOfSeats { get; set; }
    }
}
