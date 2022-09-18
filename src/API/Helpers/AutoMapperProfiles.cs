using API.DTOs.AccountDtos;
using API.DTOs.PhotoDtos;
using API.DTOs.UserDtos;
using API.Extensions;
using API.Models;
using AutoMapper;
using System.Linq;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AppUser, MemberDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));

            CreateMap<MemberUpdateDto, AppUser>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
