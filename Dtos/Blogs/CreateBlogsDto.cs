using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogsApi.Dtos.Blogs
{
    public class BlogsDto
    {
        [NotMapped]
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
