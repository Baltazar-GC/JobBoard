using AutoMapper;
using backend.Entities;
using backend.Models.OtherSkills;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class OtherSkillsService : IOtherSkillsService
    {
        private readonly IMapper _mapper;
        private readonly IOtherSkillsRepository _otherSkillsRepository;

        public OtherSkillsService(IMapper mapper, IOtherSkillsRepository otherSkillsRepository)
        {
            _mapper = mapper;
            _otherSkillsRepository = otherSkillsRepository;

        }

        public bool AddOtherSkill(OtherSkillsToCreationDto newSkill, string studentId)
        {
            var mapped = _mapper.Map<OtherSkills>(newSkill);
            mapped.StudentId = studentId;


            return _otherSkillsRepository.AddOtherSkill(mapped);
        }

        public bool DeleteOtherSkill(int deletedSkillId)
        {
            return _otherSkillsRepository.DeleteOtherSkill(deletedSkillId);
        }

        public OtherSkillsDto? GetOtherSkill(int skillId, string studentId)
        {
            var skill = _otherSkillsRepository.GetOtherSkill(skillId, studentId);

            if (skill == null) return null;

            return _mapper.Map<OtherSkillsDto>(skill);
        }

        public ICollection<OtherSkillsDto>? GetOtherSkills(string studentId)
        {
            var skills = _otherSkillsRepository.GetOtherSkills(studentId);

            if (skills == null) return null;

            return _mapper.Map<ICollection<OtherSkillsDto>>(skills);
        }

        public bool UpdateOtherSkill(OtherSkillsToUpdateDto updatedSkill, int SkillId, string studentId)
        {
            var skill = _otherSkillsRepository.GetOtherSkill(SkillId, studentId);

            skill.TechnologyName = updatedSkill.TechnologyName;
            skill.TechnologyLevelId = updatedSkill.TechnologyLevelId;

            var mapped = _mapper.Map<OtherSkills>(skill);

            return _otherSkillsRepository.UpdateOtherSkill(mapped);

        }
    }
}
