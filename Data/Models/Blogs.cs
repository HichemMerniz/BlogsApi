using System;
using System.ComponentModel.DataAnnotations;

namespace BlogsApi.Models
{
    public class BlogsM
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public int AuthorId { get; set; }

    }
}
