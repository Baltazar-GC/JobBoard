using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IStudentExtraDataRepository
    {
        bool AddStudentExtraData(StudentExtraData newStudentExtraData);
        bool UpdateStudentExtraData(StudentExtraData newStudentExtraData);
        StudentExtraData? GetStudentExtraData(string studentId);
        bool DeleteStudentExtraData(string studentId);
    }
}
