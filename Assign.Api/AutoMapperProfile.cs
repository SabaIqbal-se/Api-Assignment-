using Assign.Api.DTO;
using Assign.Api.Models;
using AutoMapper;

namespace Assign.Api
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //source mapping to destination
            CreateMap<City, CityDTO>().ForMember(des => des.CityId, opt => opt.MapFrom(src => src.CityId));
            CreateMap<Extras, ExtrasDTO>().ForMember(des => des.ExtrasId, opt => opt.MapFrom(src => src.ExtrasId));

        }
    }
}
