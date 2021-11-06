namespace BlogsApi.Models
{
    public class Blogs
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Images{ get; set; }
        public int AuthorId { get; set; }
    }
}
