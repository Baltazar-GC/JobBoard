using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface ISkillRepository
    {
        bool AddSkill(Skill newSkill);

        bool DeleteSkill(int deletedId);
        Skill? GetSkill(int skillId, string studentId);
        ICollection<Skill>? GetSkills(string studentId);
        bool UpdateSkill(Skill updatedSkill);

    }
}
