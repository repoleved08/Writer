using Newtonsoft.Json;
using System.Text;
using WriterFrontEnd.Models.Authentication;
//using WriterFrontEnd.Models;


namespace WriterFrontEnd.Services.Auth
{
    public class AuthentService : IAuthentInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseURL = "https://localhost:7036";

        public AuthentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LoginResponseDto> LoginUser(LoginDto loginDto)
        {
            var request = JsonConvert.SerializeObject(loginDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{BaseURL}/api/User/login", bodyContent);

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (result != null && result.IsSuccess)
            {
                return JsonConvert.DeserializeObject<LoginResponseDto>(result.Result.ToString());
            }
            return new LoginResponseDto();
        }



        public async Task<ResponseDto> RegisterNewUser(RegistrationDto registrationDto)
        {
            try
            {
                var request = JsonConvert.SerializeObject(registrationDto);
                var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"{BaseURL}/api/User/register", bodyContent);
                var content = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ResponseDto>(content);

                if (result.IsSuccess)
                {
                    return result;
                }
                return new ResponseDto();

            }
            catch (Exception ex)
            {

                return new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message
                };

            }
        }

    }

}
