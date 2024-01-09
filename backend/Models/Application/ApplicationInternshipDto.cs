using backend.Entities;
using backend.Models.InternshipOffer;
using backend.Models.OtherSkills;
using backend.Models.Skill;
using backend.Models.StudentCollegeInformation;
using backend.Models.StudentExtraData;
using backend.Models.StudentPersonalInformation;

namespace backend.Models.Application
{
    public class ApplicationInternshipDto
    {
        public int Id { get; set; }


        public string StudentId { get; set; }
        public Student Student { get; set; }


        public int InternshipOfferId { get; set; }
        public InternshipOfferDto InternshipOffer { get; set; }

        public DateTime ApplyDate { get; set; }


    }
}
