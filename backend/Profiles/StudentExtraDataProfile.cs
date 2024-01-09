using AutoMapper;
using backend.Entities;
using backend.Models.StudentExtraData;

namespace backend.Profiles
{
    public class StudentExtraDataProfile : Profile
    {
        public StudentExtraDataProfile()
        {
            CreateMap<StudentExtraDataToCreationDto, StudentExtraData>();
            CreateMap<StudentExtraData, StudentExtraDataToCreationDto>();


            CreateMap<StudentExtraDataToUpdateDto, StudentExtraData>();
            CreateMap<StudentExtraData, StudentExtraDataToUpdateDto>();

            CreateMap<StudentExtraData, StudentExtraDataDto>();
            CreateMap<StudentExtraDataDto, StudentExtraData>();

        }

    }
}
