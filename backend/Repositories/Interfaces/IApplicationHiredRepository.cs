using backend.Entities;
using backend.Models;

namespace backend.Repositories.Interfaces
{
    public interface IApplicationHiredRepository
    {
        bool Apply(ApplicationHired application);
        public ICollection<ApplicationHired>? GetApplicationsByJobHired(int jobOfferId);
        public ICollection<ApplicationHired>? GetApplicationsByStudent(string studentId);
        public bool CancelApply(int jobOfferId);
        public PostulantData? GetStudentData(string studentId);


    }
}
