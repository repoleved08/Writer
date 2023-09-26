namespace WriterFrontEnd.Models.Posts
{
    public class PostRequestDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Tag { get; set; }= string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public int Likes { get; set; }
        public int UnLike { get; set; }
       
    }
}
