using backend.Models.StudentCollegeInformation;

namespace backend.Services.Interfaces
{
    public interface IStudentCollegeInformationService
    {
        bool AddStudentCollegeInformation(StudentCollegeInformationToCreationDto newStudentCollegeInformation, string userId);
        bool UpdateStudentCollegeInformation(StudentCollegeInformationToUpdateDto updatedStudentCollegeInformation, string studentId);

        StudentCollegeInformationDto? GetStudentCollegeInformation(string studentId);

        bool DeleteStudentCollegeInformation(string studentId);
    }
}
