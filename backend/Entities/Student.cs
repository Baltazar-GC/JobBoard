namespace backend.Entities
{
    public class Student : User
    {


        public ICollection<Skill> Skills { get; set; }
        public ICollection<OtherSkills> OtherSkills { get; set; }
        public ICollection<ApplicationInternship> InternshipApplications { get; set; }
        public ICollection<ApplicationHired> HiredApplications { get; set; }

        public virtual StudentPersonalInformation StudentPersonalInformation { get; set; }
        public virtual StudentCollegeInformation StudentCollegeInformation { get; set; }

        public virtual StudentExtraData StudentExtraData { get; set; }


    }
}
