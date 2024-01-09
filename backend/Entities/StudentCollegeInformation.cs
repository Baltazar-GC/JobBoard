using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class StudentCollegeInformation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }


        [ForeignKey("Degree")]
        public int DegreeId { get; set; }

        public virtual Degree Degree { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        public int ApprovedSubjects { get; set; }


        [Required]
        public int YearOfStudyPlan { get; set; }

        [Required]
        public int CollegeYear { get; set; }

        [Required]
        public string Schedule { get; set; } = string.Empty;

        [Required]
        public double AverageWithNotApproved { get; set; }

        [Required]
        public double AverageWithApproved { get; set; }

    }
}
