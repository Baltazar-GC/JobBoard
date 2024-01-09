using AutoMapper;
using backend.Entities;
using backend.Models.TechnologyLevel;

namespace backend.Profiles
{
    public class TechnologyLevelProfile : Profile
    {
        public TechnologyLevelProfile()
        {
             CreateMap<TechnologyLevelToCreationDto, TechnologyLevel>();
             CreateMap<TechnologyLevel, TechnologyLevelToCreationDto>();


             CreateMap<TechnologyLevelToUpdateDto, TechnologyLevel>();
             CreateMap<TechnologyLevel, TechnologyLevelToUpdateDto>();

             CreateMap<TechnologyLevel, TechnologyLevelDto>();
             CreateMap<TechnologyLevelDto, TechnologyLevel>();
        }

       
    }
}
