using Newtonsoft.Json;
using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Posts;
using System.Text;

namespace WriterFrontEnd.Services.Posts
{

    public class PostService : IPostInterface
    {
        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7676";
        public PostService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }



        public async Task<List<Post>> GetPostsAsync()
        {

            var response = await _httpClient.GetAsync($"{BASEURL}/api/Post");
            var content = await response.Content.ReadAsStringAsync();


            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<List<Post>>(results.Result.ToString());

            }
            return new List<Post>();
        }




        public async Task<Post> LikePost(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Post/GetById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<Post>(results.Result.ToString());

            }
            return new Post();
        }

        public async Task<Post> UnLikePost(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Post/GetById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<Post>(results.Result.ToString());

            }
            return new Post();
        }

        public Task<Post> GetPostByTagAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseDto> AddPost(PostRequestDto postRequestDto)
        {
            var request = JsonConvert.SerializeObject(postRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync($"{BASEURL}/api/Post", bodyContent);
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return results;
            }
            return new ResponseDto();
        }



        public async Task<ResponseDto> DeletePost(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BASEURL}/api/Post?id={id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return results;
            }
            return new ResponseDto();
        }

        public async Task<ResponseDto> UpdatePost(Guid id, PostRequestDto postRequestDto)
        {
            var request = JsonConvert.SerializeObject(postRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync($"{BASEURL}/api/Product?id={id}", bodyContent);
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);
            if (results.IsSuccess)
            {

                return results;

            }

            return new ResponseDto();
        }

        public async Task<Post> GetPostByIdAsync(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Post/GetById/{Id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<Post>(results.Result.ToString());

            }
            return new Post();
        }
    }
}

