using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class InternshipRepository : Repository, IInternshipRepository
    {
        public InternshipRepository(ApplicationUtnContext context) : base(context)
        {

        }
        public bool AddInternshipOffer(InternshipOffer newInternshipOffer)
        {
            if (newInternshipOffer == null)
                return false;

            newInternshipOffer.IsApproved = false;

            _context.InternshipOffers.Add(newInternshipOffer);

            return SaveChanges();
        }

        public bool ApproveOffer(bool approved, int internshipId)
        {
            var offerToApprove = GetInternshipOffer(internshipId);

            if (offerToApprove is null)
                return false;

            offerToApprove.IsApproved = approved;

            return SaveChanges();
        }

        public bool DeleteInternshipOffer(int internshipId)
        {
            var infoToDelete = GetInternshipOffer(internshipId);

            if (infoToDelete is null)
                return false;

            _context.InternshipOffers.Remove(infoToDelete);
            return SaveChanges();

        }

        public ICollection<InternshipOffer?> GetAll()
        {
            var offers = _context.InternshipOffers.Include(i => i.Degree).ToList();

            if (offers is null || offers.Count == 0)
                return null;

            return offers;
        }

        public ICollection<InternshipOffer?> GetAllByEmployerId(string userId)
        {
            var offers = _context.InternshipOffers.Where(u => u.EmployerId == userId).Include(i => i.Degree).ToList();

            if (offers is null || offers.Count == 0)
                return null;

            return offers;
        }

        public ICollection<InternshipOffer?> GetApprovedInternships()
        {
            var offers = _context.InternshipOffers.Where(u => u.IsApproved == true).Include(i => i.Degree).ToList();



            return offers;
        }

        public InternshipOffer? GetInternshipOffer(int internshipId)
        {
            var binfo = _context.InternshipOffers.Include(i => i.Degree).FirstOrDefault(b => b.Id == internshipId);

            if (binfo is null)
                return null;

            return binfo;
        }

        public InternshipOffer? GetInternshipOfferByEmployerId(string userId, int internshipId)
        {
            var binfo = _context.InternshipOffers.Include(i => i.Degree).FirstOrDefault(b => b.Id == internshipId && b.EmployerId == userId);

            if (binfo is null)
                return null;

            return binfo;
        }

        public bool UpdateInternshipOffer()
        {
            return SaveChanges();
        }
    }
}