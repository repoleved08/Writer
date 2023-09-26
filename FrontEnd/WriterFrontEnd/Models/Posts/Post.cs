
using WriterFrontEnd.Models.Comments;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WriterFrontEnd.Models.Posts
{
    public class Post
    {
        [Key]
        public Guid PostId { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;



        public List<Comment> comments { get; set; }

        public string Tag { get; set; } = string.Empty;


        public DateTime DateCreated { get; set; }
        public int Likes { get; set; }
        public int UnLike { get; set; }


    }
}
