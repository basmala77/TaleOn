using AutoMapper;
using Models.DTOs;
using Models.Entities;

namespace Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // ParentProfileDto → ApplicationUser
            CreateMap<ParentProfileDto, ApplicationUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                //.ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore());

            // ApplicationUser → ParentProfileDto
            CreateMap<ApplicationUser, ParentProfileDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                //.ForMember(dest => dest.ParentImagUrl, opt => opt.MapFrom(src => src.Image != null ? src.Image.FilePath : null))
                .ForMember(dest => dest.Childrens, opt => opt.MapFrom(src => src.Children));

            // ParentProfileUpdateDto → ApplicationUser
            CreateMap<ParentProfileUpdateDto, ApplicationUser>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                //.ForMember(dest => dest.Image, opt => opt.Ignore())
                .ForMember(dest => dest.Children, opt => opt.Ignore());
        }
    }
}
