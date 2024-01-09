using backend.Models.BusinessContact;

namespace backend.Services.Interfaces
{
    public interface IBusinessContactService
    {
        bool AddBusinessContact(BusinessContactToCreationDto newBusinessContact, string userId);
        bool UpdateBusinessContact(BusinessContactToUpdateDto updatedBusinessContact, string employerId);

        BusinessContactDto GetBusinessContact(string employerId);

        bool DeleteBusinessContact(string employerId);
    }
}
