using AutoMapper;
using ConfiguringCors.Application.DTOs;
using ConfiguringCors.Domain;

namespace ConfiguringCors.WebAPI.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => Enum.GetName(src.UserType)))
                .ReverseMap();
        }
    }
}
