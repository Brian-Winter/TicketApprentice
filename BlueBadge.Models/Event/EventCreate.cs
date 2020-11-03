using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Event
{
    public class EventCreate
    {
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string EventName { get; set; }
        public int MaxTickets { get; set; }
        public int AvailableTickets { get; set; }
        public decimal ExpectedRevenue { get; set; }
    }
}
