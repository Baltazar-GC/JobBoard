using backend.Enums;
using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Degree
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DegreeLevel DegreeLevel { get; set; }

        public virtual ICollection<StudentCollegeInformation> StudentsCollegeInformation { get; set; }
    }
}
