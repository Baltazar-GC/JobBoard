using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TechnologyToCreationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
