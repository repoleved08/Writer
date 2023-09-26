using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Comments;

namespace WriterFrontEnd.Services.Comments
{
    public interface ICommentInterface
    {
        Task<List<Comment>> GetCommentsAsync();

        Task<List<Comment>> GetCommentByIdAsync(Guid id);
        Task<ResponseDto> AddCommentAsync(CommentRequestDto commentRequestDto);
        Task<ResponseDto> UpdateCommentAsync(Guid id, CommentRequestDto commentRequestDto);
        Task<ResponseDto> DeleteCommentAsync(Guid id);
    }
}
