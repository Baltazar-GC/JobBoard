using backend.Entities;
using backend.Models;

namespace backend.Repositories.Interfaces
{
    public interface IApproveEmployersRepository
    {
        public Task<ICollection<EmployerToApproveDto?>> GetEmployers();
        public Task<ICollection<EmployerToApproveDto?>> GetNotApprovedEmployers();
        public Task<ICollection<EmployerToApproveDto?>> GetApprovedEmployers();
        public Task<bool> ApproveEmployer(string employerId);
        public Task<bool> DisapproveEmployer(string employerId);

    }
}
