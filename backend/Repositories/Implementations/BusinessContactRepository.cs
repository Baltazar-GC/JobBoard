using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class BusinessContactRepository : Repository, IBusinessContactRepository
    {
        public BusinessContactRepository(ApplicationUtnContext context) : base(context)
        {

        }

        public bool AddBusinessContact(BusinessContact newBusinessContact)
        {
            if (newBusinessContact is null)
                return false;

            _context.BusinessesContacts.Add(newBusinessContact);
            return SaveChanges();
        }

        public bool DeleteBusinessContact(string employerId)
        {
            var contactToDelete = GetBusinessContact(employerId);

            if (contactToDelete is null)
                return false;

            _context.BusinessesContacts.Remove(contactToDelete);
            return SaveChanges();
        }

        public BusinessContact? GetBusinessContact(string employerId)
        {
            var bContact = _context.BusinessesContacts.FirstOrDefault(b => b.EmployerId == employerId);

            if (bContact is null)
                return null;

            return bContact;
        }

        public bool UpdateBusinessContact()
        {
            return SaveChanges();
        }
    }
}