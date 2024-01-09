using AutoMapper;
using backend.Entities;
using backend.Models.Skill;

namespace backend.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<Skill, SkillDto>();
            CreateMap<SkillDto, Skill>();

            CreateMap<SkillToCreationDto, Skill>();
            CreateMap<Skill, SkillToCreationDto>();


            CreateMap<SkillToUpdateDto, Skill>();
            CreateMap<Skill, SkillToUpdateDto>();
        }
    }
}
