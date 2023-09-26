

namespace WriterFrontEnd.Models.Comments
{
    public class Comment
    {

        public Guid CommentId { get; set; }

        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public string Tag { get; set; } = string.Empty;


    }
}
