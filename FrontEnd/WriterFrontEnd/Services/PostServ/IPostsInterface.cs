using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Posts;

namespace WriterFrontEnd.Services.PostServ
{
    public interface IPostsInterface
    {
        Task<List<Post>> GetPostsAsync();


        Task<ResponseDto> AddPost(PostRequestDto postRequestDto);
        Task<ResponseDto> DeletePost(Guid id);
        Task<ResponseDto> UpdatePost(Guid id, PostRequestDto postRequestDto);
        Task<Post> GetPostByIdAsync(Guid id);

        Task<Post> LikePost(Guid id);
        Task<Post> UnLikePost(Guid id);
        Task<Post> GetPostByTagAsync();


    }
}
