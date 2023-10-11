using AuthService.Models.RequestsDto;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Profiles
{
    public class AuthProfiles : Profile
    {
        public AuthProfiles()
        {
            CreateMap<RegistrationDto, IdentityUser>();
            CreateMap<IdentityUser, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
            // Add more properties as needed
        }
    }
    
}
