using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class UserToRegister
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        
        [Required]
        [StringLength(12, MinimumLength = 6)]
        public string Password { get; set; }
    }
}
