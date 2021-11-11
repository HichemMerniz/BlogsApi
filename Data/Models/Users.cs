using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace BlogsApi.Models
{
    public class Users : IdentityUser<int>
    {
        public DateTime Birthday { get; set; }
        public string ProfilImage { get; set; }
        
        /*Rolationship*/
        public List<BlogsM> BlogsM { get; set; }
    }
}
