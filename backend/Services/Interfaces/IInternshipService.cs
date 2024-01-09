using backend.Models.InternshipOffer;

namespace backend.Services.Interfaces
{
    public interface IInternshipService
    {
        public bool AddInternshipOffer(InternshipOfferToCreationDto newInternshipOffer, string userId);
        public bool UpdateInternshipOffer(InternshipOfferToUpdateDto updatedInternshipOffer, int internshipId);

        public InternshipOfferDto? GetInternshipOffer(int internshipId);

        public bool DeleteInternshipOffer(int internshipId);

        public ICollection<InternshipOfferDto>? GetAll();

        public ICollection<InternshipOfferDto>? GetAllByEmployerId(string userId);

        public InternshipOfferDto? GetInternshipOfferByEmployerId(string userId, int internshipId);

        public ICollection<InternshipOfferDto>? GetApprovedIntenships();

        public bool ApproveOffer(bool approved, int internshipId);

    }
}
