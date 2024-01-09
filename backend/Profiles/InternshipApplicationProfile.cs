using AutoMapper;
using backend.Entities;
using backend.Models.Application;

namespace backend.Profiles
{
    public class InternshipApplicationProfile : Profile
    {
        public InternshipApplicationProfile()
        {
            CreateMap<ApplicationInternshipToCreationDto, ApplicationInternship>();
            CreateMap<ApplicationInternship, ApplicationInternshipToCreationDto>();



            CreateMap<ApplicationInternship, ApplicationInternshipDto>();
            CreateMap<ApplicationInternshipDto, ApplicationInternship>();
        }
    }
}
