using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.StudentPersonalInformation
{
    public class StudentPersonalInformationToCreationDto
    {



        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Legajo { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Cuit { get; set; } = string.Empty;


        [Required]
        public string SecondaryEmail { get; set; } = string.Empty;

        [Required]
        public IdentifierType IdentifierType { get; set; } = IdentifierType.DNI;

        [Required]
        public string IndentifierNumber { get; set; } = string.Empty;

        [Required]
        public string DateOfBith { get; set; } = string.Empty;

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string MaritalStatus { get; set; } = string.Empty;

        [Required]
        public string CurrentAddress { get; set; } = string.Empty;

        [Required]
        public string CurrentHomeNumber { get; set; } = string.Empty;

        [Required]
        public string FloorNumber { get; set; } = string.Empty;

        [Required]
        public string Apartment { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;

        [Required]
        public string Province { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public string SecondaryPhoneNumber { get; set; } = string.Empty;

        [Required]
        public string FamilyCountry { get; set; } = string.Empty;

        [Required]
        public string FamilyProvince { get; set; } = string.Empty;

        [Required]
        public string FamilyCity { get; set; } = string.Empty;

        [Required]
        public string FamilyAddress { get; set; } = string.Empty;

        [Required]
        public string FamilyPhoneNumber { get; set; } = string.Empty;

        [Required]
        public string SecondaryFamilyPhoneNumber { get; set; } = string.Empty;

        [Required]
        public string FamilyNumberHome { get; set; } = string.Empty;

    }
}
