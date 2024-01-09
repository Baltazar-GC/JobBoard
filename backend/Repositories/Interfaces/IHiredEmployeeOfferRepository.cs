using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IHiredEmployeeOfferRepository 
    {
        public bool AddHiredEmployeeOffer(HiredEmployeeOffer newHiredEmployeeOffer);
        public bool UpdateHiredEmployeeOffer();

        HiredEmployeeOffer? GetHiredEmployeeOffer(int internshipId);
        public bool DeleteHiredEmployeeOffer(int internshipId);

        public ICollection<HiredEmployeeOffer?> GetAll();
        public ICollection<HiredEmployeeOffer?> GetAllByEmployerId(string userId);

        HiredEmployeeOffer? GetHiredEmployeeOfferByEmployerId(string userId, int internshipId);
        
    }
}
