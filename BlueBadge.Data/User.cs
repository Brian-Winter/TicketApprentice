using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadge.Data
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public int Name { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
