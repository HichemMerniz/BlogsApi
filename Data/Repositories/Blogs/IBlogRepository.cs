using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogsApi.Models;

namespace BlogsApi.Data.Repositories
{
    public interface IBlogRepository
    {
        List<BlogsM> GetAllBlogs();
        BlogsM Get(int id);
        BlogsM Add(BlogsM blogs);
        BlogsM Update(int id, BlogsM blogs);
        BlogsM Delete(int id);
    }
}

