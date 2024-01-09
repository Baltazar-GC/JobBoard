using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class OtherSkillsRepository : Repository, IOtherSkillsRepository
    {
        public OtherSkillsRepository(ApplicationUtnContext context) : base(context)
        {
        }


        public bool AddOtherSkill(OtherSkills newOtherSkill)
        {

            var exists = _context.OtherSkills.FirstOrDefault(s => s.TechnologyName == newOtherSkill.TechnologyName);

            if (exists != null)
                return false;

            _context.OtherSkills.Add(newOtherSkill);



            return SaveChanges();
        }

        public bool DeleteOtherSkill(int deletedId)
        {
            var skillToRemove = _context.OtherSkills.FirstOrDefault(s => s.OtherSkillsId == deletedId);

            if (skillToRemove is null)
                return false;

            _context.OtherSkills.Remove(skillToRemove);

            return SaveChanges();

        }

        public OtherSkills? GetOtherSkill(int skillId, string studentId)
        {
            return _context.OtherSkills?.FirstOrDefault(s => s.OtherSkillsId == skillId && s.StudentId == studentId);
        }

        public ICollection<OtherSkills>? GetOtherSkills(string studentId)
        {
            return _context.OtherSkills?.Where(f => f.StudentId == studentId).Include(s => s.TechnologyLevel).ToList();
        }



        public bool UpdateOtherSkill(OtherSkills updatedSkill)
        {
            var skillToUpdate = _context.OtherSkills.FirstOrDefault(s => s.OtherSkillsId == updatedSkill.OtherSkillsId);

            if (skillToUpdate is null)
                return false;

            skillToUpdate.TechnologyLevel = updatedSkill.TechnologyLevel;

            return SaveChanges();
        }
    }
}
