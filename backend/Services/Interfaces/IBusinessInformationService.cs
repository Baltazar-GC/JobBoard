using backend.Models.BusinessInformation;

namespace backend.Services.Interfaces
{
    public interface IBusinessInformationService
    {
        bool AddBusinessInformation(BusinessInformationToCreationDto newBusinessInformation, string employerId);
        bool UpdateBusinessInformation(BusinessInformationToUpdateDto updatedBusinessInformation, string employerId);

        BusinessInformationDto? GetBusinessInformation(string employerId);

        bool DeleteBusinessInformation(string employerId);


    }
}
