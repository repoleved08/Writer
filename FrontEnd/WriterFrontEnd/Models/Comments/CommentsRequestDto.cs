namespace WriterFrontEnd.Models.Comments
{
    public class CommentRequestDto
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
        public string Body { get; set; } = string.Empty;
    }
}
