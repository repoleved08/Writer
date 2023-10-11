
using Newtonsoft.Json;
using WriterFrontEnd.Models;
using WriterFrontEnd.Models.Comments;
using System.Text;

namespace WriterFrontEnd.Services.Comments
{
    public class CommentService : ICommentInterface

    {

        private readonly HttpClient _httpClient;
        private readonly string BASEURL = "https://localhost:7676";
        public CommentService(HttpClient httpClient)
        {

            _httpClient = httpClient;

        }
        public async Task<ResponseDto> AddCommentAsync(CommentRequestDto commentRequestDto)
        {
            var request = JsonConvert.SerializeObject(commentRequestDto);
            var bodyContent = new StringContent(request, Encoding.UTF8, "application/json");


            var response = await _httpClient.PostAsync($"{BASEURL}/api/Comment", bodyContent);
            var content = await response.Content.ReadAsStringAsync();

            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return results;
            }
            return new ResponseDto();
        }

        public async Task<ResponseDto> DeleteCommentAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"{BASEURL}/api/Comment?id={id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return results;
            }
            return new ResponseDto();
        }

        public async Task<List<Comment>> GetCommentByIdAsync(Guid Id)
        {
            var response = await _httpClient.GetAsync($"{BASEURL}/api/Comment/GetById/={Id}");
            var content = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<List<Comment>>(results.Result.ToString());

            }
            return new List<Comment>();
        }

        public async Task<List<Comment>> GetCommentsAsync()
        {

            var response = await _httpClient.GetAsync($"{BASEURL}/api/Comment");
            var content = await response.Content.ReadAsStringAsync();


            var results = JsonConvert.DeserializeObject<ResponseDto>(content);

            if (results.IsSuccess)
            {

                return JsonConvert.DeserializeObject<List<Comment>>(results.Result.ToString());

            }
            return new List<Comment>();
        }

        public async Task<ResponseDto> UpdateCommentAsync(Guid id, CommentRequestDto commentRequestDto)
        {
            var request = JsonConvert.SerializeObject(commentRequestDto);
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



    }
}
