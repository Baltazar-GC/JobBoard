using System.ComponentModel.DataAnnotations;

namespace backend.Models.BusinessContact
{
    public class BusinessContactToUpdateDto
    {
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string SecondaryPhone { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public bool IsAnEmployee { get; set; }
    }
}
