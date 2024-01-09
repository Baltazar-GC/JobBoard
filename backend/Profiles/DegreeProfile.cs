using AutoMapper;
using backend.Entities;
using backend.Models.Degree;

namespace backend.Profiles
{
    public class DegreeProfile : Profile
    {
        public DegreeProfile()
        {
            CreateMap<DegreeToCreationDto, Degree>();
            CreateMap<Degree, DegreeToCreationDto>();


            CreateMap<DegreeToUpdateDto, Degree>();
            CreateMap<Degree, DegreeToUpdateDto>();

            CreateMap<Degree, DegreeDto>();
            CreateMap<DegreeDto, Degree>();
        }
    }
}
