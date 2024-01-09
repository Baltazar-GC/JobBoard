using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        [ForeignKey("TechnologyLevel")]
        public int TechnologyLevelId { get; set; }
        public virtual TechnologyLevel TechnologyLevel { get; set; }

        [ForeignKey("Technology")]
        public int TechnologyId { get; set; }
        public virtual Technology Technology { get; set; }


        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }



    }
}
