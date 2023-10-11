using AuthService.Models.RequestsDto;
using AuthService.Models.ResponseDto;

namespace AuthService.Services.IServices
{
    public interface IUserInterface
    {
        Task<string> RegisterUser(RegistrationDto registrationDto);

        Task<LoginResponseDto> LoginUser(LoginDto loginDto);

        Task<IEnumerable<PostDto>> GetPostsOfThisUser();
    }
}
