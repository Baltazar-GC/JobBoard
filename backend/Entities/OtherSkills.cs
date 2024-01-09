using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class OtherSkills
    {
        [Key]
        public int OtherSkillsId { get; set; }

        [ForeignKey("TechnologyLevel")]
        public int TechnologyLevelId { get; set; }
        public virtual TechnologyLevel TechnologyLevel { get; set; }

        [Required]
        public string TechnologyName { get; set; } = string.Empty;

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
