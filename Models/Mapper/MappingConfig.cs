using AutoMapper;
using Models.DTOs;
using Models.Entities;
namespace Models.Mapper
{
    public class MappingConfig : Profile
    {
        // This class is used to configure AutoMapper mappings.
        // You can define your mappings here, for example:
        // public static IMapper CreateMapper() => new MapperConfiguration(cfg => {
        //     cfg.CreateMap<SourceModel, DestinationModel>();
        // }).CreateMapper();

        // Currently, this class is empty and can be extended as needed.
        public MappingConfig()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }

    }
}
