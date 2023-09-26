using WriterFrontEnd.Models.Posts;

namespace WriterFrontEnd.Services.Posting
{
    public interface IPostsInterface
    {
        Task<List<Post>> GetPostsAsync();
    }
}
