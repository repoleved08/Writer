using AuthService.Models.RequestsDto;
using AuthService.Models.ResponseDto;
using AuthService.Services.IServices;
using MessageBusLib;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SenderBus;
using System.Security.Claims;


namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        private readonly IConfiguration _configuration;
        private readonly ResponseDto _response;
        private readonly IMessageBus _messageBus;
        private readonly ISenderBus _senderBus;


        public UserController(IUserInterface userInterface, IConfiguration configuration, ISenderBus senderBus)
        {
            _userInterface = userInterface;
            _configuration = configuration;
            _senderBus = senderBus;
            _response = new ResponseDto();
        }

        [HttpPost("register")]
        public async Task<ActionResult<ResponseDto>> AddUSer(RegistrationDto Registration)
        {
            var message = await _userInterface.RegisterUser(Registration);
            if (message == "User created successfully!")
            {
                //start
                var queueName = _configuration.GetSection("QueueTopic:RegU").Get<string>();
                var messageToQueue = new UserMessage()
                {
                    Email = Registration.Email,
                    Name = Registration.UserName
                };
                await _senderBus.PublishMessage(messageToQueue, queueName);
                _response.IsSuccess = true;
                _response.Message = message;
                //end
                //var queueName = _configuration.GetSection("Queues:RegisterUser").Get<string>();
                //var messagequeue = new UserMessage()
                //{
                //    Email = Registration.Email,
                //    Name = Registration.UserName
                //};
                //await _messageBus.PublishMessage(messagequeue, queueName);
                //_response.IsSuccess = true;
                //_response.Message = message;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = message;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ResponseDto>> LoginUser(LoginDto loginDto)
        {
            var token = await _userInterface.LoginUser(loginDto);
            if (token != null)
            {
                _response.IsSuccess = true;
                _response.Message = "User logged in successfully!";
                _response.Result = token;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = "Invalid login credentials!";
                return BadRequest(_response);
            }
        }
        //get all post of this user
        [HttpGet("getUserPosts")]
        [Authorize]
        public async Task<ActionResult<ResponseDto>> GetPostsOfThisUser()
        {
            //get the user id from the token
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            var loggedId = userIdClaim.Value;

            //get all posts
            var posts = await _userInterface.GetPostsOfThisUser();

            //get the posts of this user
            var UserPosts = posts.Where(x => x.UserId == loggedId).ToList();
            if (UserPosts != null)
            {
                _response.IsSuccess = true;
                _response.Message = "Posts fetched successfully!";
                _response.Result = UserPosts;
                return Ok(_response);
            }
            else
            {
                _response.IsSuccess = false;
                _response.Message = "No posts found!";
                return NotFound(_response);
            }
        }


    }
}
