using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface ITechnologyLevelRepository
    {
        bool AddLevel(TechnologyLevel newLevel);
        TechnologyLevel? GetLevel(int levelId);
        bool IsLevel(int levelId);
        ICollection<TechnologyLevel>? GetLevels();
        bool UpdateLevel();
        bool DeleteLevel(int deletedLevelId);
    }
}
