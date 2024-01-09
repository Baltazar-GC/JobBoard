using AutoMapper;
using backend.Entities;
using backend.Models.BusinessInformation;

namespace backend.Profiles
{
    public class BusinessInformationProfile : Profile
    {
        public BusinessInformationProfile()
        {
            CreateMap<BusinessInformationToCreationDto, BusinessInformation>();
            CreateMap<BusinessInformation, BusinessInformationToCreationDto>();

            CreateMap<BusinessInformationToUpdateDto, BusinessInformation>();
            CreateMap<BusinessInformation, BusinessInformationToUpdateDto>();

            CreateMap<BusinessInformation, BusinessInformationDto>();
            CreateMap<BusinessInformationDto, BusinessInformation>();
        }
    }
}
