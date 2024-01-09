using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IStudentCollegeInformationRepository
    {
        bool AddStudentCollegeInformation(StudentCollegeInformation newStudentCollegeInformation);
        bool UpdateStudentCollegeInformation();
        StudentCollegeInformation? GetStudentCollegeInformation(string studentId);
        bool DeleteStudentCollegeInformation(string studentId);
    }
}
