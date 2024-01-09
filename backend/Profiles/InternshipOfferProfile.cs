using AutoMapper;
using backend.Entities;
using backend.Models.InternshipOffer;

namespace backend.Profiles
{
    public class InternshipOfferProfile : Profile
    {
        public InternshipOfferProfile()
        {
            CreateMap<InternshipOfferToCreationDto, InternshipOffer>();
            CreateMap<InternshipOffer, InternshipOfferToCreationDto>();


            CreateMap<InternshipOfferToUpdateDto, InternshipOffer>();
            CreateMap<InternshipOffer, InternshipOfferToUpdateDto>();

            CreateMap<InternshipOffer, InternshipOfferDto>();
            CreateMap<InternshipOfferDto, InternshipOffer>();
        }
    }
}
