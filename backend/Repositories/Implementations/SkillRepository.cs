using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class SkillRepository : Repository, ISkillRepository
    {
        public SkillRepository(ApplicationUtnContext context) : base(context)
        {
        }


        public bool AddSkill(Skill newSkill)
        {

            var exists = _context.Skills.FirstOrDefault(s => s.TechnologyId == newSkill.TechnologyId);

            if (exists != null)
                return false;

            _context.Skills.Add(newSkill);



            return SaveChanges();
        }

        public bool DeleteSkill(int deletedId)
        {
            var skillToRemove = _context.Skills.FirstOrDefault(s => s.SkillId == deletedId);

            if (skillToRemove is null)
                return false;

            _context.Skills.Remove(skillToRemove);

            return SaveChanges();

        }

        public Skill? GetSkill(int skillId, string studentId)
        {
            return _context.Skills?.FirstOrDefault(s => s.SkillId == skillId && s.StudentId == studentId);
        }

        public ICollection<Skill>? GetSkills(string studentId)
        {
            return _context.Skills?
                .Where(f => f.StudentId == studentId)
                .Include(s => s.Technology)
                .Include(g => g.TechnologyLevel)
                .ToList();
        }



        public bool UpdateSkill(Skill updatedSkill)
        {
            var skillToUpdate = _context.Skills.FirstOrDefault(s => s.SkillId == updatedSkill.SkillId);

            if (skillToUpdate is null)
                return false;

            skillToUpdate.TechnologyLevel = updatedSkill.TechnologyLevel;
            skillToUpdate.Technology = updatedSkill.Technology;

            return SaveChanges();
        }
    }
}
