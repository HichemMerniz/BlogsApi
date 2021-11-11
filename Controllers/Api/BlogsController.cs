using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BlogsApi.Data.Repositories;
using BlogsApi.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using BlogsApi.Dtos.Blogs;
using System.Linq;



namespace BlogsApi.Controllers.Api
{
    [Authorize]
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly IBlogRepository _blogRepository;
        private  BlogDBContext _blogDBContext;
        

        public BlogsController(IBlogRepository blogRepository,BlogDBContext blogDBContext)
        {
            _blogRepository = blogRepository;
            _blogDBContext = blogDBContext;
        }

        [HttpGet]
        public ActionResult<List<BlogsM>> GetAll() => _blogRepository.GetAllBlogs();

        [HttpGet("{id}"),Authorize]
        public ActionResult<BlogsM> GetOnBlog(int id)=>  _blogRepository.Get(id);

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Create(BlogsDto blogsDto)
        {
            var blogs = new BlogsM
            {
                Title = blogsDto.Title,
                Description = blogsDto.Description,
                AuthorId = blogsDto.AuthorId,
            };
           var blogCreated = _blogRepository.Add(blogs);
            ;
            return Ok(new {message = "success",data = blogs });
        }

        [HttpPut("{id}")]
        public ActionResult Put(int Id,BlogsDto blogsDto)
        {
            var blog = _blogDBContext.Set<BlogsM>().FirstOrDefault(b => b.Id == Id);
            if (blog != null)
            {
                blog.Title = blogsDto.Title;
                blog.Description = blogsDto.Description;
                blog.Images = blogsDto.Images;
                blog.AuthorId = blogsDto.AuthorId;
            }
            var blogUpdated = _blogRepository.Update(blog);
            _blogDBContext.SaveChanges();
            if (blog == null)
            {
                return BadRequest();
            }
            

            return Ok($"success");
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var blog = _blogRepository.Delete(id);
            if (blog == null)
            {
                return BadRequest();
            }
            return Ok("delete success");
        }

    }
}
