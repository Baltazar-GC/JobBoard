using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class StudentExtraDataRepository : Repository, IStudentExtraDataRepository
    {
        public StudentExtraDataRepository(ApplicationUtnContext context) : base(context)
        {

        }

        public bool AddStudentExtraData(StudentExtraData newStudentExtraData)
        {
            if (newStudentExtraData == null)
                return false;
            _context.StudentsExtraData.Add(newStudentExtraData);
            return SaveChanges();
        }

        public bool DeleteStudentExtraData(string studentId)
        {
            var infoToDelete = GetStudentExtraData(studentId);

            if (infoToDelete is null)
                return false;
            _context.StudentsExtraData.Remove(infoToDelete);
            return SaveChanges();
        }

        public StudentExtraData? GetStudentExtraData(string studentId)
        {
            var bInfo = _context.StudentsExtraData.FirstOrDefault(b => b.StudentId == studentId);

            if (bInfo is null)
                return null;
            return bInfo;
        }

        public bool UpdateStudentExtraData(StudentExtraData newStudentExtraData)
        {
            var toUpdate = _context.StudentsExtraData.FirstOrDefault(b => b.StudentId == newStudentExtraData.StudentId);

            if (toUpdate == null)
                return false;

            toUpdate.HighSchoolDegree = newStudentExtraData.HighSchoolDegree;
            toUpdate.Curriculum = newStudentExtraData.Curriculum;
            toUpdate.Comments = newStudentExtraData.Comments;

            _context.StudentsExtraData.Update(toUpdate);
            return SaveChanges();
        }
    }

}

