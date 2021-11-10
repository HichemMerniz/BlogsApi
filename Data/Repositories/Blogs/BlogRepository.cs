using BlogsApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BlogsApi.Data.Repositories.Blogs
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDBContext _blogDBContext;
        public BlogRepository(BlogDBContext blogDBContext)
        {
            _blogDBContext = blogDBContext;
        }
        public BlogsM Add(BlogsM blog)
        {
            _blogDBContext.Set<BlogsM>().Add(blog);
            blog.Id = _blogDBContext.SaveChanges();
            return blog;
        }

        public BlogsM Get(int id)
        {
            return _blogDBContext.Set<BlogsM>().Find(id); 
        }

        public List<BlogsM> GetAllBlogs()
        {
            return _blogDBContext.Set<BlogsM>().ToList();
        }

        public BlogsM Update(int id, BlogsM blogs)
        {
            _blogDBContext.Entry(blogs).State = EntityState.Modified;
            _blogDBContext.SaveChanges();
            return blogs;
        }
        public BlogsM Delete(int id)
        {
            var blog = _blogDBContext.Set<BlogsM>().FirstOrDefault(b => b.Id == id);
            if(blog == null)
            {
                return blog; 
            }
            _blogDBContext.Set<BlogsM>().Remove(blog);
            _blogDBContext.SaveChanges();
            return blog; 
        }
    }
}
