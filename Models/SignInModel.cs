using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlikHalafim.Models
{
    public class SignInModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string ErrorMessage = "סיסמה או מייל לא נכונים";
        public bool Error { get; set; }
    }
}
