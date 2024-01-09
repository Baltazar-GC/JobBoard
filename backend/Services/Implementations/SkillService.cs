using AutoMapper;
using backend.Entities;
using backend.Models.Skill;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{

    public class SkillService : ISkillService
    {
        private readonly IMapper _mapper;
        private readonly ISkillRepository _skillRepository;

        public SkillService(IMapper mapper, ISkillRepository skillRepository)
        {
            _mapper = mapper;
            _skillRepository = skillRepository;

        }

        public bool AddSkill(SkillToCreationDto newSkill, string studentId)
        {
            var mapped = _mapper.Map<Skill>(newSkill);
            mapped.StudentId = studentId;


            return _skillRepository.AddSkill(mapped);
        }

        public bool DeleteSkill(int deletedSkillId)
        {
            return _skillRepository.DeleteSkill(deletedSkillId);
        }

        public SkillDto? GetSkill(int skillId, string studentId)
        {
            var skill = _skillRepository.GetSkill(skillId, studentId);

            if (skill == null) return null;

            return _mapper.Map<SkillDto>(skill);
        }

        public ICollection<SkillDto>? GetSkills(string studentId)
        {
            var skills = _skillRepository.GetSkills(studentId);

            if (skills == null) return null;

            return _mapper.Map<ICollection<SkillDto>>(skills);
        }

        public bool UpdateSkill(SkillToUpdateDto updatedSkill, int SkillId, string studentId)
        {
            var skill = _skillRepository.GetSkill(SkillId, studentId);

            skill.TechnologyId = updatedSkill.TechnologyId;
            skill.TechnologyLevelId = updatedSkill.TechnologyLevelId;

            var mapped = _mapper.Map<Skill>(skill);

            return _skillRepository.UpdateSkill(mapped);

        }
    }
}
