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

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
