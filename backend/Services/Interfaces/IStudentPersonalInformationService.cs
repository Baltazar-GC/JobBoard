using backend.Models.StudentPersonalInformation;

namespace backend.Services.Interfaces
{
    public interface IStudentPersonalInformationService
    {
        bool AddStudentPersonalInformation(StudentPersonalInformationToCreationDto newStudentPersonalInformation, string userId);
        bool UpdateStudentPersonalInformation(StudentPersonalInformationToUpdateDto updatedStudentPersonalInformation, string studentId);

        StudentPersonalInformationDto? GetStudentPersonalInformation(string studentId);

        bool DeleteStudentPersonalInformation(string studentId);
    }
}
