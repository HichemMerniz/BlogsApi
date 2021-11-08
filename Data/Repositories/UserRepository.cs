using BlogsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogsApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BlogDBContext _blogDBContext;
        public UserRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }
        
        public Users Register(Users user)
        {
            _blogDBContext.Users.Add(user);
            user.Id= _blogDBContext.SaveChanges();
            return user;
        }

        public Users GetByEmail(string email)
        {
            return _blogDBContext.Users.Where(u => u.Email == email).SingleOrDefault();
        }
    }
}
