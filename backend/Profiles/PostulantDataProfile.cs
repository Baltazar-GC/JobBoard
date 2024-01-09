using AutoMapper;
using backend.Entities;
using backend.Models;

namespace backend.Profiles
{
    public class PostulantDataProfile : Profile
    {
        public PostulantDataProfile()
        {
            CreateMap<PostulantData, PostulantDataDto>();
            CreateMap<PostulantDataDto, PostulantData>();
        }
    }
}
