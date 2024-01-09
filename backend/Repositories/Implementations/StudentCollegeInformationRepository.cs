using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
   
    public class StudentCollegeInformationRepository : Repository, IStudentCollegeInformationRepository
        {
            public StudentCollegeInformationRepository(ApplicationUtnContext context) : base(context)
            {

            }

            public bool AddStudentCollegeInformation(StudentCollegeInformation newStudentCollegeInformation)
            {
                if (newStudentCollegeInformation == null)
                    return false;
                _context.StudentsCollegeInformation.Add(newStudentCollegeInformation);
                return SaveChanges();
            }

            public bool DeleteStudentCollegeInformation(string studentId)
            {
                var infoToDelete = GetStudentCollegeInformation(studentId);

                if (infoToDelete is null)
                    return false;
                _context.StudentsCollegeInformation.Remove(infoToDelete);
                return SaveChanges();
            }

            public StudentCollegeInformation? GetStudentCollegeInformation(string studentId)
            {
                var bInfo = _context.StudentsCollegeInformation.FirstOrDefault(b => b.StudentId == studentId);

                if (bInfo is null)
                    return null;
                return bInfo;
            }

            public bool UpdateStudentCollegeInformation()
            {
                return SaveChanges();
            }
        }
    }
