namespace backend.Models.StudentCollegeInformation
{
    public class StudentCollegeInformationToUpdateDto
    {



        public int DegreeId { get; set; }


        public int ApprovedSubjects { get; set; }


        public int YearOfStudyPlan { get; set; }


        public int CollegeYear { get; set; }


        public string Schedule { get; set; } = string.Empty;


        public double AverageWithNotApproved { get; set; }


        public double AverageWithApproved { get; set; }

    }
}
