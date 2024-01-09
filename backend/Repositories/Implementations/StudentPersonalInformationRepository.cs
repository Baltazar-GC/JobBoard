using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class StudentPersonalInformationRepository : Repository, IStudentPersonalInformationRepository
    {
        public StudentPersonalInformationRepository(ApplicationUtnContext context) : base(context)
        {

        }

        public bool AddStudentPersonalInformation(StudentPersonalInformation newStudentPersonalInformation)
        {
            if (newStudentPersonalInformation == null)
                return false;
            _context.StudentsPersonalInformation.Add(newStudentPersonalInformation);
            return SaveChanges();
        }

        public bool DeleteStudentPersonalInformation(string studentId)
        {
            var infoToDelete = GetStudentPersonalInformation(studentId);

            if (infoToDelete is null)
                return false;
            _context.StudentsPersonalInformation.Remove(infoToDelete);
            return SaveChanges();
        }

        public StudentPersonalInformation? GetStudentPersonalInformation(string studentId)
        {
            var bInfo = _context.StudentsPersonalInformation.FirstOrDefault(b => b.StudentId == studentId);

            if (bInfo is null)
                return null;
            return bInfo;
        }

        public bool UpdateStudentPersonalInformation()
        {
            return SaveChanges();
        }
    }

}

