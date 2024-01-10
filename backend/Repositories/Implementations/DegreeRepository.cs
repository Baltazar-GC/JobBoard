using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class DegreeRepository : Repository, IDegreeRepository
    {
        public DegreeRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public async Task<bool> Add(Degree newDegree)
        {
            _context.Degrees?.Add(newDegree);

            return await SaveChanges();
        }

        public async Task<bool> Delete(int deletedDegreeId)
        {
            var degree = await Get(deletedDegreeId);

            if (degree == null)
                return false;

            _context.Degrees.Remove(degree);
            return await SaveChanges();
        }

        public Task<Degree?> Get(int degreeId)
        {
            return _context.Degrees.FirstOrDefaultAsync(d => d.Id == degreeId);
        }

        public async Task<ICollection<Degree>> List()
        {
            var degrees = await _context.Degrees.ToListAsync();

            return degrees;
        }

        public async Task<bool> Update(Degree updatedDegree)
        {
            _context.Degrees.Update(updatedDegree);

            return await SaveChanges();
        }
    }
}
