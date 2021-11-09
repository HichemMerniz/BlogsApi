using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsApi.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email{ get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Password{ get; set; }
    }
}
