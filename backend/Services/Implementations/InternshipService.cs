using AutoMapper;
using backend.Entities;
using backend.Models.InternshipOffer;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class InternshipService : IInternshipService
    {

        private readonly IMapper _mapper;
        private readonly IInternshipRepository _InternshipOfferRepository;

        public InternshipService(IMapper mapper, IInternshipRepository InternshipOfferRepository)
        {
            _mapper = mapper;
            _InternshipOfferRepository = InternshipOfferRepository;
        }

        public bool AddInternshipOffer(InternshipOfferToCreationDto newInternshipOffer, string userId)
        {
            if (newInternshipOffer == null)
                return false;

            InternshipOffer mapped = _mapper.Map<InternshipOffer>(newInternshipOffer);

            mapped.EmployerId = userId;

            return _InternshipOfferRepository.AddInternshipOffer(mapped);
        }

        public bool DeleteInternshipOffer(int internshipId)
        {
            return _InternshipOfferRepository.DeleteInternshipOffer(internshipId);
        }

        public InternshipOfferDto? GetInternshipOffer(int internshipId)
        {
            var info = _InternshipOfferRepository.GetInternshipOffer(internshipId);

            if (info == null)
                return null;

            var mapped = _mapper.Map<InternshipOfferDto>(info);

            return mapped;
        }


        public bool UpdateInternshipOffer(InternshipOfferToUpdateDto updatedInternshipOffer, int internshipId)
        {
            if (updatedInternshipOffer == null)
                return false;

            var businessToUpdate = _InternshipOfferRepository.GetInternshipOffer(internshipId);

            if (businessToUpdate == null)
                return false;

            _mapper.Map(updatedInternshipOffer, businessToUpdate);

            return _InternshipOfferRepository.UpdateInternshipOffer();
        }

        public ICollection<InternshipOfferDto>? GetAll()
        {
            var offers = _InternshipOfferRepository.GetAll();

            if (offers == null || offers.Count() <= 0)
                return null;



            return _mapper.Map<ICollection<InternshipOfferDto>>(offers);
        }

        public ICollection<InternshipOfferDto>? GetAllByEmployerId(string userId)
        {
            var offers = _InternshipOfferRepository.GetAllByEmployerId(userId);

            if (offers == null || offers.Count() <= 0)
                return null;



            return _mapper.Map<ICollection<InternshipOfferDto>>(offers);
        }

        public InternshipOfferDto? GetInternshipOfferByEmployerId(string userId, int internshipId)
        {
            var info = _InternshipOfferRepository.GetInternshipOfferByEmployerId(userId, internshipId);

            if (info == null)
                return null;

            var mapped = _mapper.Map<InternshipOfferDto>(info);

            return mapped;
        }

        public ICollection<InternshipOfferDto>? GetApprovedIntenships()
        {
            var offers = _InternshipOfferRepository.GetApprovedInternships();

            if (offers == null || offers.Count() <= 0)
                return null;



            return _mapper.Map<ICollection<InternshipOfferDto>>(offers);
        }

        public bool ApproveOffer(bool approved, int internshipId)
        {
            return _InternshipOfferRepository.ApproveOffer(approved, internshipId);
        }
    }
}
