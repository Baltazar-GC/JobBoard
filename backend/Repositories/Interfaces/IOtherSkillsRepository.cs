using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IOtherSkillsRepository
    {
        bool AddOtherSkill(OtherSkills newSkill);
        bool DeleteOtherSkill(int deletedId);
        OtherSkills? GetOtherSkill(int otherSkillId, string studentId);
        ICollection<OtherSkills>? GetOtherSkills(string studentId);
        bool UpdateOtherSkill(OtherSkills updatedOtherSkill);
    }
}
