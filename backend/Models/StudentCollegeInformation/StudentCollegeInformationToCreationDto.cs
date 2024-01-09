using System.ComponentModel.DataAnnotations;

namespace backend.Models.StudentCollegeInformation
{
    public class StudentCollegeInformationToCreationDto
    {


        [Required]
        public int DegreeId { get; set; }

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
