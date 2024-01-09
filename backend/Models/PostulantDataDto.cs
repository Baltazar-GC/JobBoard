using backend.Models.OtherSkills;
using backend.Models.Skill;
using backend.Models.StudentCollegeInformation;
using backend.Models.StudentExtraData;
using backend.Models.StudentPersonalInformation;

namespace backend.Models
{
    public class PostulantDataDto
    {
        public StudentPersonalInformationDto StudentPersonalInformation { get; set; }
        public StudentCollegeInformationDto StudentCollegeInformation { get; set; }
        public ICollection<SkillDto> StudentSkills { get; set; }
        public ICollection<OtherSkillsDto> OtherSkills { get; set; }
        //public StudentExtraDataDto StudentExtraData { get; set; }

    }
}
