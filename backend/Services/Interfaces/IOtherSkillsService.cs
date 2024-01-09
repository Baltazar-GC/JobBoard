using backend.Models.OtherSkills;

namespace backend.Services.Interfaces
{
    public interface IOtherSkillsService
    {
        OtherSkillsDto? GetOtherSkill(int skillId, string studentId);
        ICollection<OtherSkillsDto>? GetOtherSkills(string studentId);
        bool AddOtherSkill(OtherSkillsToCreationDto newSkill, string studentId);
        bool UpdateOtherSkill(OtherSkillsToUpdateDto updatedSkill, int SkillId, string studentId);
        bool DeleteOtherSkill(int deletedSkillId);
    }
}
