using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public enum TicketTier
    {
        General, 
        LowerLevel,
        VIP
    }
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }

        [ForeignKey(nameof(User))]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public decimal Cost { get; set; }
        public string SeatName { get; set; }
    }
}
