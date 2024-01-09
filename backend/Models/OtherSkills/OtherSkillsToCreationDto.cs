using System.ComponentModel.DataAnnotations;

namespace backend.Models.OtherSkills
{
    public class OtherSkillsToCreationDto
    {

        [Required]
        public int TechnologyLevelId { get; set; }

        [Required]
        public string TechnologyName { get; set; } = string.Empty;
    }
}
