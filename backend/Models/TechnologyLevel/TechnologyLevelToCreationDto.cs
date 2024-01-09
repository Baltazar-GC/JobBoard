using System.ComponentModel.DataAnnotations;

namespace backend.Models.TechnologyLevel
{
    public class TechnologyLevelToCreationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
