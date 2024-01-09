using System.ComponentModel.DataAnnotations;

namespace backend.Models.Skill
{
    public class SkillToCreationDto
    {
        [Required]
        public int TechnologyId { get; set; }
        [Required]
        public int TechnologyLevelId { get; set; }
    }
}
