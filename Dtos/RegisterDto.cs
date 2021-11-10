﻿using System.ComponentModel.DataAnnotations;

namespace BlogsApi.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string FullName { get; set; }
        [Required,EmailAddress]
        public string Email { get; set; }
        [Required,MinLength(8)]
        public string Password { get; set; }
       
 
    }
}
