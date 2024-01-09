using AutoMapper;
using backend.Contexts;
using backend.Entities;
using backend.Models;
using backend.Models.OtherSkills;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class ApplicationHiredRepository : Repository, IApplicationHiredRepository
    {
        public ApplicationHiredRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public bool Apply(ApplicationHired application)
        {
            application.ApplyDate = DateTime.Now;


            var exist = _context.HiredApplications
                .FirstOrDefault(i => i.StudentId == application.StudentId && i.HiredEmployeeOfferId == application.HiredEmployeeOfferId);

            if (exist != null)
                return false;


            _context.HiredApplications.Add(application);

            return SaveChanges();
        }

        public bool CancelApply(int jobOfferId)
        {
            var toDelete = _context.HiredApplications.FirstOrDefault(h => h.HiredEmployeeOfferId == jobOfferId);
            if (toDelete is null)
                return false;
            _context.Remove(toDelete);
            return SaveChanges();
        }

        public ICollection<ApplicationHired>? GetApplicationsByJobHired(int jobOfferId)
        {


            var applications = _context.HiredApplications
                .Where(a => a.HiredEmployeeOfferId == jobOfferId)
                .Include(h => h.HiredEmployeeOffer)
                .ToList();


            return applications;

        }

        public ICollection<ApplicationHired>? GetApplicationsByStudent(string studentId)
        {
            var applications = _context.HiredApplications
                .Where(a => a.StudentId == studentId)
                .Include(h => h.HiredEmployeeOffer)
                .ToList();


            return applications;
        }

        public PostulantData? GetStudentData(string studentId)
        {
            var studentData = new PostulantData();


            var oskills = _context.OtherSkills
                .Where(o => o.StudentId == studentId)
                .ToList();

            if (oskills is null)
                return null;

            studentData.OtherSkills = oskills;

            var skillss = _context.Skills
                .Where(s => s.StudentId == studentId)
                .ToList();

            if (skillss is null)
                return null;

            studentData.StudentSkills = skillss;

            var pers = _context.StudentsPersonalInformation
                .FirstOrDefault(p => p.StudentId == studentId);

            if (pers is null)
                return null;

            studentData.StudentPersonalInformation = pers;

            var coll = _context.StudentsCollegeInformation
                .FirstOrDefault(c => c.StudentId == studentId);

            if (coll is null)
                return null;

            studentData.StudentCollegeInformation = coll;

            //var cv = _context.StudentsExtraData.FirstOrDefault(os => os.StudentId == studentId);

            //if (cv is null)
            //    return null;

            //studentData.StudentExtraData = cv;

            return studentData;

        }
    }
}
