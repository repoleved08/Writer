using ServicePost.Model;

namespace ServicePost.Services.IServices
{
    public interface IPostInterface
    {

        //create post
        Task<string> CreatePost(Post post);
        //get all posts
        Task<List<Post>> GetPosts();

        //get post by id
        Task<Post> GetPostById(Guid id);

        //update post
        Task<string> UpdatePost(Post post);

        //delete post
        Task<string> DeletePost(Post post);

    }
}
