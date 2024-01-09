using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IBusinessInformationRepository
    {
        bool AddBusinessInformation(BusinessInformation newBusinessInformation);
        bool UpdateBusinessInformation();

        BusinessInformation? GetBusinessInformation(string employerId);

        bool DeleteBusinessInformation(string employerId);
    }
}
