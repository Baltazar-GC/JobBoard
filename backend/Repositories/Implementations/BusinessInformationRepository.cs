using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class BusinessInformationRepository : Repository, IBusinessInformationRepository
    {
        public BusinessInformationRepository(ApplicationUtnContext context) : base(context)
        {

        }
        public bool AddBusinessInformation(BusinessInformation newBusinessInformation)
        {
            if (newBusinessInformation == null)
                return false;


            _context.BusinessesInformation.Add(newBusinessInformation);

            return SaveChanges();
        }

        public bool DeleteBusinessInformation(string employerId)
        {
            var infoToDelete = GetBusinessInformation(employerId);

            if (infoToDelete is null)
                return false;

            _context.BusinessesInformation.Remove(infoToDelete);
            return SaveChanges();

        }

        public BusinessInformation? GetBusinessInformation(string employerId)
        {
            var binfo = _context.BusinessesInformation.FirstOrDefault(b => b.EmployerId == employerId);

            if (binfo is null)
                return null;

            return binfo;
        }

        public bool UpdateBusinessInformation()
        {
            return SaveChanges();
        }
    }
}
