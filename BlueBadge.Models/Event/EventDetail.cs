using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Event
{
    public class EventDetail
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string EventName { get; set; }
        public int MaxTickets { get; set; }
        public int AvailableTickets { get; set; }
        public decimal ExpectedRevenue { get; set; }
    }
}
