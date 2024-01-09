using backend.Models.TechnologyLevel;

namespace backend.Models.OtherSkills
{
    public class OtherSkillsDto
    {
        public int OtherSkillsId { get; set; }

        public int TechnologyLevelId { get; set; }
        public virtual TechnologyLevelDto TechnologyLevel { get; set; }

        public string TechnologyName { get; set; } = string.Empty;

        public string StudentId { get; set; }
    }
}
