using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profiles
{
    public class TechnologyProfile : Profile
    {
        public TechnologyProfile()
        {
            CreateMap<TechnologyToCreationDto, Technology>();
            CreateMap<Technology, TechnologyToCreationDto>();


            CreateMap<TechnologyToUpdateDto, Technology>();
            CreateMap<Technology, TechnologyToUpdateDto>();

            CreateMap<Technology, TechnologyDto>();
            CreateMap<TechnologyDto, Technology>();
        }
    }
}
