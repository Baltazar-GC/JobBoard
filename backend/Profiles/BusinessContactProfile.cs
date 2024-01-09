using AutoMapper;
using backend.Entities;
using backend.Models.BusinessContact;

namespace backend.Profiles
{
    public class BusinessContactProfile : Profile
    {
        public BusinessContactProfile()
        {
            CreateMap<BusinessContactToCreationDto, BusinessContact>();
            CreateMap<BusinessContact, BusinessContactToCreationDto>();


            CreateMap<BusinessContactToUpdateDto, BusinessContact>();
            CreateMap<BusinessContact, BusinessContactToUpdateDto>();

            CreateMap<BusinessContact, BusinessContactDto>();
            CreateMap<BusinessContactDto, BusinessContact>();
        }
    }
}
