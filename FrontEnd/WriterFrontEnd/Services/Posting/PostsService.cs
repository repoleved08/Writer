using Newtonsoft.Json;
using System.Text.Json.Serialization;
using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Posts;

namespace WriterFrontEnd.Services.Posting
{
    public class PostsService : IPostsInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseURL = "https://localhost:7133";

        public PostsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Post>> GetPostsAsync()
        {
            var response = await _httpClient.GetAsync($"{BaseURL}/api/Post");

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (result != null && result.IsSuccess)
            {
                return JsonConvert.DeserializeObject<List<Post>>(result.Result.ToString());
            }
            return new List<Post>();
        }
    }
}
