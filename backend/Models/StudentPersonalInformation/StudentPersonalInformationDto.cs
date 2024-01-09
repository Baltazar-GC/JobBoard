using backend.Enums;

namespace backend.Models.StudentPersonalInformation
{
    public class StudentPersonalInformationDto
    {

        public int Id { get; set; }

        public string StudentId { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Legajo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public string Cuit { get; set; } = string.Empty;

        public string SecondaryEmail { get; set; } = string.Empty;

        public IdentifierType IdentifierType { get; set; } = IdentifierType.DNI;

        public string IndentifierNumber { get; set; } = string.Empty;

        public string DateOfBith { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string MaritalStatus { get; set; } = string.Empty;

        public string CurrentAddress { get; set; } = string.Empty;

        public string CurrentHomeNumber { get; set; } = string.Empty;

        public string FloorNumber { get; set; } = string.Empty;
        public string Apartment { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;


        public string Province { get; set; } = string.Empty;


        public string City { get; set; } = string.Empty;


        public string PhoneNumber { get; set; } = string.Empty;


        public string SecondaryPhoneNumber { get; set; } = string.Empty;


        public string FamilyCountry { get; set; } = string.Empty;


        public string FamilyProvince { get; set; } = string.Empty;


        public string FamilyCity { get; set; } = string.Empty;


        public string FamilyAddress { get; set; } = string.Empty;


        public string FamilyPhoneNumber { get; set; } = string.Empty;


        public string SecondaryFamilyPhoneNumber { get; set; } = string.Empty;


        public string FamilyNumberHome { get; set; } = string.Empty;

    }
}
