using System.ComponentModel.DataAnnotations;

namespace backend.Models.BusinessInformation
{
    public class BusinessInformationToCreationDto
    {


        [Required]
        public string BusinessName { get; set; } = string.Empty;

        [Required]
        public string Cuit { get; set; } = string.Empty;

        [Required]
        public string LineOfBusiness { get; set; } = string.Empty;

        [Required]
        public string LegalAddress { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string PhoneNumer { get; set; } = string.Empty;

        public string Web { get; set; } = string.Empty;
    }
}
