using System.ComponentModel.DataAnnotations;

namespace backend.Models.BusinessInformation
{
    public class BusinessInformationToUpdateDto
    {

        public string BusinessName { get; set; } = string.Empty;

        public string Cuit { get; set; } = string.Empty;

        public string LineOfBusiness { get; set; } = string.Empty;

        public string LegalAddress { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string PostalCode { get; set; } = string.Empty;

        public string PhoneNumer { get; set; } = string.Empty;

        public string Web { get; set; } = string.Empty;
    }
}
