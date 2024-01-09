using System.ComponentModel.DataAnnotations;

namespace backend.Models.TechnologyLevel
{
    public class TechnologyLevelToUpdateDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
