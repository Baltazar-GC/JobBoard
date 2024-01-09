using backend.Models.Skill;

namespace backend.Services.Interfaces
{
    public interface ISkillService
    {
        SkillDto? GetSkill(int skillId, string studentId);
        ICollection<SkillDto>? GetSkills(string studentId);
        bool AddSkill(SkillToCreationDto newSkill, string studentId);
        bool UpdateSkill(SkillToUpdateDto updatedSkill, int SkillId, string studentId);
        bool DeleteSkill(int deletedSkillId);
    }
}
