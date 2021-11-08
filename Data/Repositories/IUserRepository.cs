using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogsApi.Models;

namespace BlogsApi.Data.Repositories
{
    public interface IUserRepository
    {
        Users Register(Users user);
        Users GetByEmail(string email);
    }
}
