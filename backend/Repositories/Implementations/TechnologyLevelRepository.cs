using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories.Implementations
{
    public class TechnologyLevelRepository : Repository, ITechnologyLevelRepository
    {
        public TechnologyLevelRepository(ApplicationUtnContext context) : base(context)
        {
        }

        public async Task<bool> Add(TechnologyLevel newLevel)
        {
            _context.TechnologyLevels?.Add(newLevel);

            return await SaveChanges();
        }

        public async Task<bool> Delete(int deletedLevelId)
        {
            var level = await Get(deletedLevelId);

            if (level != null)
            {
                _context.TechnologyLevels.Remove(level);

                return await SaveChanges();
            }

            return false;
        }

        public async Task<TechnologyLevel?> Get(int levelId)
        {
            return await _context.TechnologyLevels.FirstOrDefaultAsync(d => d.TechnologyLevelId == levelId);
        }

        public async Task<ICollection<TechnologyLevel>> List()
        {
            return await _context.TechnologyLevels.ToListAsync();
        }

        public async Task<bool> Update(TechnologyLevel updatedLevel)
        {
            _context.Update(updatedLevel);

            return await SaveChanges();
        }
    }
}
