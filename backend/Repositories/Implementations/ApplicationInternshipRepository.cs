using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class ApplicationInternshipRepository : Repository, IApplicationInternshipRepository
    {
        public ApplicationInternshipRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public bool Apply(ApplicationInternship application)
        {
            application.ApplyDate = DateTime.Now;

            var exist = _context.InternshipApplications
                .FirstOrDefault(i => i.StudentId == application.StudentId && i.InternshipOfferId == application.InternshipOfferId);

            if (exist != null)
                return false;


            _context.InternshipApplications.Add(application);

            return SaveChanges();

        }

        public bool CancelApply(int jobOfferId)
        {
            var toDelete = _context.InternshipApplications.FirstOrDefault(h => h.InternshipOfferId == jobOfferId);
            if (toDelete is null)
                return false;
            _context.Remove(toDelete);
            return SaveChanges();
        }

        public ICollection<ApplicationInternship>? GetApplicationsByJobInternship(int jobOfferId)
        {


            var applications = _context.InternshipApplications
                .Where(a => a.InternshipOfferId == jobOfferId)
                .Include(h => h.InternshipOffer)
                .ToList();


            return applications;

        }


        public ICollection<ApplicationInternship>? GetApplicationsByStudent(string studentId)
        {
            var applications = _context.InternshipApplications
                .Where(a => a.StudentId == studentId)
                .Include(h => h.InternshipOffer)
                .ToList();


            return applications;
        }
    }
}
