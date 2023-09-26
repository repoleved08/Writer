using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Authentication;

namespace WriterFrontEnd.Services.Auth
{
    public interface IAuthentInterface
    {
        Task<ResponseDto> RegisterNewUser(RegistrationDto registrationDto);

        Task<LoginResponseDto> LoginUser(LoginDto loginDto);
    }
}
