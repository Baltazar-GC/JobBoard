using backend.Entities;
using backend.Models.TechnologyLevel;

namespace backend.Models.Skill
{
    public class SkillDto
    {
        public TechnologyLevelDto TechnologyLevel { get; set; }
        public TechnologyDto Technology { get; set; }
        public int TechnologyId { get; set; }
        public int TechnologyLevelId { get; set; }
        public int SkillId { get; set; }

        public string StudentId { get; set; }


    }
}
