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
        General =1, 
        LowerLevel,
        VIP
    }
    public enum DemandOfEventTicketScale
    {
        low =1,
        medium,
        high,
        extreme
    }
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }
        public virtual Event Event { get; set; }
                
        public Guid? UserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public string SeatName { get; set; }
        [Required]
        public TicketTier TierOfTicket { get; set; }
        [Required]
        public DemandOfEventTicketScale TicketDemand { get; set; }
    }
}
