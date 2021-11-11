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

        public BlogsM Update(BlogsM blogChanges)
        {
            var blog = _blogDBContext.Set<BlogsM>().FirstOrDefault(b => b.Id == blogChanges.Id);
            
            if (blog == null)
            {
                return blog;
            }
            _blogDBContext.Set<BlogsM>().Update(blogChanges);
            _blogDBContext.SaveChanges();
            /* if(blog != null)
             {
                     blog.Title = blogChanges.Title;
                     blog.Description=blogChanges.Description;
                     blog.Images=blogChanges.Images;
                     blog.AuthorId=blogChanges.AuthorId;
             };            
             _blogDBContext.SaveChanges();*/

            return blogChanges; 
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
