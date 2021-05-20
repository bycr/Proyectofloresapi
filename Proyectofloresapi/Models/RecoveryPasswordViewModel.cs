using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyectofloresapi.Models
{
    public class RecoveryPasswordViewModel
    {
        [StringLength(50)]
        public string token { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [StringLength(50, MinimumLength = 5,
        ErrorMessage = "Last Name should be minimum 3 characters and a maximum of 50 characters")]
        public string Password2 { get; set; }
    }
}