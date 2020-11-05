using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.TicketModels
{
    public class TicketEdit
    {
        public int TicketId { get; set; }
        public decimal Cost { get; set; }
        public string SeatName { get; set; }
    }
}
