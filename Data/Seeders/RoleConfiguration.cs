using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogsApi.Data.Seeders
{
    public class UserRoles 
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
