using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogsApi.Data.Repositories;
using BlogsApi.Models;
using Microsoft.AspNetCore.Authorization;
using BlogsApi.Dtos.Blogs;

namespace BlogsApi.Controllers.Api
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : Controller
    {
        private readonly IBlogRepository _blogRepository;

        public BlogsController(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
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
            
            return Created("Success", _blogRepository.Add(blogs));
        }

    }
}
