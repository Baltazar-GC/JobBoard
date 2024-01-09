using backend.Models;
using backend.Models.Application;

namespace backend.Services.Interfaces
{
    public interface IApplicationHiredService
    {
        ICollection<ApplicationHiredDto>? GetApplicationsByHired(int jobOfferId);
        public bool Apply(ApplicationHiredToCreationDto application, string studentId);
        ICollection<ApplicationHiredDto>? GetApplicationsByStudent(string studentId);
        public bool CancelApply(int jobOfferId);
        public PostulantDataDto? GetPostulantData(string studentId);
    }
}
