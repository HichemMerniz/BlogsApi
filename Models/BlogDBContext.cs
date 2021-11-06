using Microsoft.EntityFrameworkCore;

namespace BlogsApi.Models
{
    public class BlogDBContext : DbContext
    {
        public BlogDBContext(DbContextOptions<BlogDBContext> opt) : base(opt)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Blogs> Blogs{ get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
