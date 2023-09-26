using AutoMapper;
using ServicePost.Model;
using ServicePost.Model.Dto;

namespace ServicePost.Profiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<AddPost, Post>().ReverseMap();
            CreateMap<Post, PostResponse>().ReverseMap();
        }
    }
}
