using AutoMapper;
using trackerApi.Data;
using trackerApi.Models.Weights;
using trackerApi.Models.Users;

namespace trackerApi.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Weight, UserWeightDto>().ReverseMap();
            CreateMap<Weight, CreateWeightDto>().ReverseMap();
            CreateMap<ApiUserDto, User>().ReverseMap();
        }

    }
}
