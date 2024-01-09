using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Degree
{
    public class DegreeToCreationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DegreeLevel DegreeLevel { get; set; }
    }
}
