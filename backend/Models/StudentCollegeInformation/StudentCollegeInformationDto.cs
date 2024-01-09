using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models.StudentCollegeInformation
{
    public class StudentCollegeInformationDto
    {

        public int Id { get; set; }


        public string StudentId { get; set; }



        public int DegreeId { get; set; }



        public int ApprovedSubjects { get; set; }



        public int YearOfStudyPlan { get; set; }


        public int CollegeYear { get; set; }


        public string Schedule { get; set; } = string.Empty;


        public double AverageWithNotApproved { get; set; }


        public double AverageWithApproved { get; set; }

    }
}
