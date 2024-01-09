using backend.Contexts;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly ApplicationUtnContext _context;

        public Repository(ApplicationUtnContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
