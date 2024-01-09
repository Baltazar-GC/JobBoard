using System.ComponentModel.DataAnnotations;

namespace backend.Models.BusinessContact
{
    public class BusinessContactToCreationDto
    {



        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string SecondaryPhone { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool IsAnEmployee { get; set; }
    }
}
