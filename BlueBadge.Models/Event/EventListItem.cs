using BlueBadge.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Event
{
    public class EventListItem
    {
        public int EventId { get; set; }
        public DateTime Date { get; set; }
        public string EventName { get; set; }
    }
}
