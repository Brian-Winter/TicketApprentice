using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class Event
    {
        [Key]
        public int EventId { get; set; }

        [ForeignKey(nameof(Venue))]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        public DateTime Date { get; set; }
        public string EventName { get; set; }
        public int MaxTickets { get; set; }
        public int AvailableTickets { get; set; }
        public decimal ExpectedRevenue { get; set; }
    }
}
