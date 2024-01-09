using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class DegreeRepository : Repository, IDegreeRepository
    {
        public DegreeRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public bool AddDegree(Degree newDegree)
        {
            if (newDegree is null)
                return false;

            _context.Degrees?.Add(newDegree);

            return SaveChanges();
        }

        public bool DeleteDegree(int deletedDegreeId)
        {
            var degree = GetDegree(deletedDegreeId);

            if (degree == null)
                return false;

            _context.Degrees?.Remove(degree);
            return SaveChanges();
        }

        public Degree? GetDegree(int degreeId)
        {
            var degreeExist = IsDegree(degreeId);
            if (degreeExist)
                return _context.Degrees?.FirstOrDefault(d => d.Id == degreeId);
            return null;
        }

        public ICollection<Degree>? GetDegrees()
        {
            var degrees = _context.Degrees?.ToList();

            if (degrees is null || degrees.Count() <= 0)
                return null;

            return degrees;
        }

        public bool IsDegree(int degreeId)
        {
            var degree = _context.Degrees?.FirstOrDefault(d => d.Id == degreeId);
            if (degree is null)
                return false;
            return true;
        }

        public bool UpdateDegree()
        {
            return SaveChanges();
        }
    }
}
