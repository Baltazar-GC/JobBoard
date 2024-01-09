using backend.Models.Application;

namespace backend.Services.Interfaces
{
    public interface IApplicationInternshipService
    {
        ICollection<ApplicationInternshipDto>? GetApplicationsByInternship(int jobOfferId);
        public bool Apply(ApplicationInternshipToCreationDto application, string studentId);
        ICollection<ApplicationInternshipDto>? GetApplicationsByStudent(string studentId);
        public bool CancelApply(int jobOfferId);


    }
}
