using System.ComponentModel.DataAnnotations;

namespace backend.Models.Application
{
    public class ApplicationInternshipToCreationDto
    {
        [Required]
        public int InternshipOfferId { get; set; }

    }
}
