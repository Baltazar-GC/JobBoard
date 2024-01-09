using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Models.HiredEmployeeOffer;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class HiredEmployeeOfferService : IHiredEmployeeOfferService
    {
        private readonly IMapper _mapper;
        private readonly IHiredEmployeeOfferRepository _HiredEmployeeOfferRepository;

        public HiredEmployeeOfferService(IMapper mapper, IHiredEmployeeOfferRepository HiredEmployeeOfferRepository)
        {
            _mapper = mapper;
            _HiredEmployeeOfferRepository = HiredEmployeeOfferRepository;
        }

        public bool AddHiredEmployeeOffer(HiredEmployeeOfferToCreationDto newHiredEmployeeOffer, string userId)
        {
            if (newHiredEmployeeOffer == null)
                return false;

            HiredEmployeeOffer mapped = _mapper.Map<HiredEmployeeOffer>(newHiredEmployeeOffer);

            mapped.EmployerId = userId;

            return _HiredEmployeeOfferRepository.AddHiredEmployeeOffer(mapped);
        }

        public bool DeleteHiredEmployeeOffer(int HiredEmployeeOfferId)
        {
            return _HiredEmployeeOfferRepository.DeleteHiredEmployeeOffer(HiredEmployeeOfferId);
        }

        public HiredEmployeeOfferDto? GetHiredEmployeeOffer(int HiredEmployeeOfferId)
        {
            var info = _HiredEmployeeOfferRepository.GetHiredEmployeeOffer(HiredEmployeeOfferId);

            if (info == null)
                return null;

            var mapped = _mapper.Map<HiredEmployeeOfferDto>(info);

            return mapped;
        }

        public bool UpdateHiredEmployeeOffer(HiredEmployeeOfferToUpdateDto updatedHiredEmployeeOffer, int HiredEmployeeOfferId)
        {
            if (updatedHiredEmployeeOffer == null)
                return false;

            var businessToUpdate = _HiredEmployeeOfferRepository.GetHiredEmployeeOffer(HiredEmployeeOfferId);

            if (businessToUpdate == null)
                return false;

            _mapper.Map(updatedHiredEmployeeOffer, businessToUpdate);

            return _HiredEmployeeOfferRepository.UpdateHiredEmployeeOffer();
        }
        public ICollection<HiredEmployeeOfferDto>? GetAll()
        {
            var offers = _HiredEmployeeOfferRepository.GetAll();

            if (offers == null || offers.Count() <= 0)
                return null;

            return _mapper.Map<ICollection<HiredEmployeeOfferDto>>(offers);
        }

        public ICollection<HiredEmployeeOfferDto>? GetAllByEmployerId(string userId)
        {
            var offers = _HiredEmployeeOfferRepository.GetAllByEmployerId(userId);

            if (offers == null || offers.Count() <= 0)
                return null;

            return _mapper.Map<ICollection<HiredEmployeeOfferDto>>(offers);
        }

        public HiredEmployeeOfferDto? GetHiredEmployeeOfferByEmployerId(string userId, int HiredEmployeeOfferId)
        {
            var info = _HiredEmployeeOfferRepository.GetHiredEmployeeOfferByEmployerId(userId, HiredEmployeeOfferId);

            if (info == null)
                return null;

            var mapped = _mapper.Map<HiredEmployeeOfferDto>(info);

            return mapped;
        }
    }
}
