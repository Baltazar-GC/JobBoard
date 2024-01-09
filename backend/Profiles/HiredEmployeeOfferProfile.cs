using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Models.HiredEmployeeOffer;

namespace backend.Profiles
{
    public class HiredEmployeeOfferProfile : Profile
    {
        public HiredEmployeeOfferProfile()
        {
            CreateMap<HiredEmployeeOfferToCreationDto, HiredEmployeeOffer>();
            CreateMap<HiredEmployeeOffer, HiredEmployeeOfferToCreationDto>();


            CreateMap<HiredEmployeeOfferToUpdateDto, HiredEmployeeOffer>();
            CreateMap<HiredEmployeeOffer, HiredEmployeeOfferToUpdateDto>();

            CreateMap<HiredEmployeeOffer, HiredEmployeeOfferDto>();
            CreateMap<HiredEmployeeOfferDto, HiredEmployeeOffer>();
        }
    }
}
