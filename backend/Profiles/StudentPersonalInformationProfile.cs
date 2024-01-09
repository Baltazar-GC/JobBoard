using AutoMapper;
using backend.Entities;
using backend.Models.StudentPersonalInformation;

namespace backend.Profiles
{
    public class StudentPersonalInformationProfile : Profile
    {
        public StudentPersonalInformationProfile()
        {
            CreateMap<StudentPersonalInformationToCreationDto, StudentPersonalInformation>();
            CreateMap<StudentPersonalInformation, StudentPersonalInformationToCreationDto>();


            CreateMap<StudentPersonalInformationToUpdateDto, StudentPersonalInformation>();
            CreateMap<StudentPersonalInformation, StudentPersonalInformationToUpdateDto>();

            CreateMap<StudentPersonalInformation, StudentPersonalInformationDto>();
            CreateMap<StudentPersonalInformationDto, StudentPersonalInformation>();

        }
    }
}
