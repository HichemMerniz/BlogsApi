using System.ComponentModel.DataAnnotations;

namespace BlogsApi.Dtos.Blogs
{
    public class BlogsDto
    {
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Images { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}
