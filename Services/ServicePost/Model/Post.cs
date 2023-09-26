namespace ServicePost.Model
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string UserId { get; set; }


    }
}
