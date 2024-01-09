using AutoMapper;
using backend.Entities;
using backend.Models.StudentCollegeInformation;

namespace backend.Profiles
{
    public class StudentCollegeInformationProfile : Profile
    {
        public StudentCollegeInformationProfile()
        {
            CreateMap<StudentCollegeInformationToCreationDto, StudentCollegeInformation>();
            CreateMap<StudentCollegeInformation, StudentCollegeInformationToCreationDto>();


            CreateMap<StudentCollegeInformationToUpdateDto, StudentCollegeInformation>();
            CreateMap<StudentCollegeInformation, StudentCollegeInformationToUpdateDto>();

            CreateMap<StudentCollegeInformation, StudentCollegeInformationDto>();
            CreateMap<StudentCollegeInformationDto, StudentCollegeInformation>();

        }
    }
}
