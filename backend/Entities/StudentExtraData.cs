using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class StudentExtraData
    {
        [Key]
        public int Id { get; set; }
        public byte[]? Curriculum { get; set; }
        public string HighSchoolDegree { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

        [ForeignKey("Student")]
        public string StudentId { get; set; } = string.Empty;
        public virtual Student Student { get; set; }
    }
}
