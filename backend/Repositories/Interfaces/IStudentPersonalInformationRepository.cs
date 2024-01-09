using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IStudentPersonalInformationRepository
    {
        bool AddStudentPersonalInformation(StudentPersonalInformation newStudentPersonalInformation);
        bool UpdateStudentPersonalInformation();
        StudentPersonalInformation? GetStudentPersonalInformation(string studentId);
        bool DeleteStudentPersonalInformation(string studentId);
    }
}
