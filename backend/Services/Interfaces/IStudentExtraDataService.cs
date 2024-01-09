using backend.Models.StudentExtraData;

namespace backend.Services.Interfaces
{
    public interface IStudentExtraDataService
    {
        bool AddStudentExtraData(StudentExtraDataToCreationDto newStudentExtraData, string userId);

        StudentExtraDataDto? GetStudentExtraData(string studentId);

        bool DeleteStudentExtraData(string studentId);
    }
}
