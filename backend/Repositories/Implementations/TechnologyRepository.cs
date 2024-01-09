using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class TechnologyRepository : Repository, ITechnologyRepository
    {
        public TechnologyRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public async Task<bool> Add(Technology newTechnology)
        {
            if (newTechnology is null)
                return false;

            _context.Technologies?.Add(newTechnology);

            return await SaveChanges();
        }

        public async Task<bool> Delete(int deletedTechnologyId)
        {
            var technology = await Get(deletedTechnologyId);

            if (technology == null)
                return false;

            _context.Technologies?.Remove(technology);

            return await SaveChanges();
        }

        public async Task<Technology?> Get(int technologyId)
        {
            return await _context.Technologies.FirstOrDefaultAsync(d => d.TechnologyId == technologyId);
        }

        public async Task<ICollection<Technology>> List()
        {
            var technologies = await _context.Technologies.ToListAsync();

            return technologies;
        }

        public async Task<bool> Update(Technology updatedTechnology)
        {
            _context.Update(updatedTechnology);

            return await SaveChanges();
        }
    }
}
