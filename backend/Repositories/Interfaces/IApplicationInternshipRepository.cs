using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IApplicationInternshipRepository
    {
        ICollection<ApplicationInternship>? GetApplicationsByJobInternship(int jobOfferId);
        bool Apply(ApplicationInternship application);
        public ICollection<ApplicationInternship>? GetApplicationsByStudent(string studentId);
        public bool CancelApply(int jobOfferId);

    }
}
