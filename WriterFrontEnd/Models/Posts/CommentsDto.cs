

namespace WriterFrontEnd.Models.Posts
{
    public class CommentsDto
    {
        
        public Guid CommentId { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        
    }
}
