namespace backend.Entities
{
    public class PostulantData
    {

        public StudentPersonalInformation StudentPersonalInformation { get; set; }
        public StudentCollegeInformation StudentCollegeInformation { get; set; }
        public ICollection<Skill> StudentSkills { get; set; }
        public ICollection<OtherSkills> OtherSkills { get; set; }
        public StudentExtraData StudentExtraData { get; set; }

    }
}
