using AutoMapper;
using backend.Entities;
using backend.Models.Application;

namespace backend.Profiles
{
    public class HiredApplicationProfile : Profile
    {
        public HiredApplicationProfile()
        {

            CreateMap<ApplicationHired, ApplicationHiredDto>();
            CreateMap<ApplicationHiredDto, ApplicationHired>();

            CreateMap<ApplicationHiredToCreationDto, ApplicationHired>();
            CreateMap<ApplicationHired, ApplicationHiredToCreationDto>();


        }
    }
}
