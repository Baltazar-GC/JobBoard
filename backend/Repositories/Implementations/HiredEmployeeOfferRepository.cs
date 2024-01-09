using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class HiredEmployeeOfferRepository : Repository, IHiredEmployeeOfferRepository
    {
        public HiredEmployeeOfferRepository(ApplicationUtnContext context) : base(context)
        {

        }
        public bool AddHiredEmployeeOffer(HiredEmployeeOffer newHiredEmployeeOffer)
        {
            if (newHiredEmployeeOffer == null)
                return false;

            _context.HiredEmployeeOffers.Add(newHiredEmployeeOffer);

            return SaveChanges();
        }

        public bool DeleteHiredEmployeeOffer(int hiredEmployeeOfferId)
        {
            var infoToDelete = GetHiredEmployeeOffer(hiredEmployeeOfferId);

            if (infoToDelete is null)
                return false;

            _context.HiredEmployeeOffers.Remove(infoToDelete);
            return SaveChanges();

        }

        public ICollection<HiredEmployeeOffer?> GetAll()
        {
            var offers = _context.HiredEmployeeOffers.Include(i => i.Degree).ToList();

            if (offers is null || offers.Count == 0)
                return null;

            return offers;
        }

        public ICollection<HiredEmployeeOffer?> GetAllByEmployerId(string userId)
        {
            var offers = _context.HiredEmployeeOffers.Where(u => u.EmployerId == userId).Include(i => i.Degree).ToList();

            if (offers is null || offers.Count == 0)
                return null;

            return offers;
        }


        public HiredEmployeeOffer? GetHiredEmployeeOffer(int hiredEmployeeOfferId)
        {
            var binfo = _context.HiredEmployeeOffers.Include(i => i.Degree).FirstOrDefault(b => b.Id == hiredEmployeeOfferId);

            if (binfo is null)
                return null;

            return binfo;
        }

        public HiredEmployeeOffer? GetHiredEmployeeOfferByEmployerId(string userId, int hiredEmployeeOfferId)
        {
            var binfo = _context.HiredEmployeeOffers.Include(i => i.Degree).FirstOrDefault(b => b.Id == hiredEmployeeOfferId && b.EmployerId == userId);

            if (binfo is null)
                return null;

            return binfo;
        }

        public bool UpdateHiredEmployeeOffer()
        {
            return SaveChanges();
        }
    }
}
