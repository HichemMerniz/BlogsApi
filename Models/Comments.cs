namespace BlogsApi.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int AuthorId { get; set; }
        public int BlogId { get; set; }
        public string content { get; set; }
    }
}
