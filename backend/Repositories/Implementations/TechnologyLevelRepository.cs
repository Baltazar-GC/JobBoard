using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class TechnologyLevelRepository : Repository, ITechnologyLevelRepository
    {
        private readonly ISkillRepository _skillRepository;
        public TechnologyLevelRepository(ApplicationUtnContext context, ISkillRepository skillRepository) : base(context)
        {
            _skillRepository = skillRepository;
        }


        public bool AddLevel(TechnologyLevel newLevel)
        {
            if (newLevel is null)
                return false;

            _context.TechnologyLevels?.Add(newLevel);


            return SaveChanges();

        }

        public bool DeleteLevel(int deletedLevelId)
        {
            var level = GetLevel(deletedLevelId);
            if (level != null)
            {
                _context.TechnologyLevels?.Remove(level);

                return SaveChanges();
            }
            return false;

        }

        public TechnologyLevel? GetLevel(int levelId)
        {
            var levelExist = IsLevel(levelId);
            if (levelExist)
                return _context.TechnologyLevels?.FirstOrDefault(d => d.TechnologyLevelId == levelId);
            return null;
        }

        public ICollection<TechnologyLevel>? GetLevels()
        {
            return _context.TechnologyLevels?.ToList();
        }

        public async Task<bool> UpdateLevel(TechnologyLevel updatedLevel)
        {
            this._context.Update(updatedLevel);

            return await SaveChanges();
        }
    }
}
