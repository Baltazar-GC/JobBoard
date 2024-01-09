using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IBusinessContactRepository
    {
        bool AddBusinessContact(BusinessContact newBusinessContact);
        bool UpdateBusinessContact();
        BusinessContact? GetBusinessContact(string employerId);
        bool DeleteBusinessContact(string employerId);
    }
}
