using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IInternshipRepository
    {
        public bool AddInternshipOffer(InternshipOffer newInternshipOffer);
        public bool UpdateInternshipOffer();

        InternshipOffer? GetInternshipOffer(int internshipId);
        public bool DeleteInternshipOffer(int internshipId);

        public ICollection<InternshipOffer?> GetAll();
        public ICollection<InternshipOffer?> GetAllByEmployerId(string userId);

        InternshipOffer? GetInternshipOfferByEmployerId(string userId, int internshipId);
        public ICollection<InternshipOffer?> GetApprovedInternships();
        public bool ApproveOffer(bool approved, int internshipId);



    }
}
