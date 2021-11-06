using System;

namespace BlogsApi.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDay{ get; set; }
        public string ProfilImage { get; set; }
        public string Role{ get; set; }

    }
}
