using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Proyectofloresapi.Models
{
    public class RecoveryViewModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
    }
}