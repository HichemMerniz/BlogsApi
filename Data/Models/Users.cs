using Microsoft.AspNetCore.Identity;
using System;

namespace BlogsApi.Models
{
    public class Users : IdentityUser
    {
        public DateTime Birthday { get; set; }
        public string ProfilImage { get; set; }
    }
}
