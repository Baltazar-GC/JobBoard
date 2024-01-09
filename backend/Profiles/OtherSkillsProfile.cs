using AutoMapper;
using backend.Entities;
using backend.Models.OtherSkills;

namespace backend.Profiles
{
    public class OtherSkillsProfile : Profile
    {
        public OtherSkillsProfile()
        {
            CreateMap<OtherSkills, OtherSkillsDto>();
            CreateMap<OtherSkillsDto, OtherSkills>();

            CreateMap<OtherSkillsToCreationDto, OtherSkills>();
            CreateMap<OtherSkills, OtherSkillsToCreationDto>();


            CreateMap<OtherSkillsToUpdateDto, OtherSkills>();
            CreateMap<OtherSkills, OtherSkillsToUpdateDto>();
        }
    }
}
