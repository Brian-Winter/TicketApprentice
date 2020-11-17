using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Models.Venue
{
    public class VenueCreate
    {
        [Required]
        public int VenueId { get; set; }
        [Required]
        public string VenueName { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "Please enter two letter state abbreviation")]
        [MaxLength(2, ErrorMessage = "Please enter two letter state abbreviation")]
        public string State { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
    }
}
