using backend.Entities;
using backend.Models.TechnologyLevel;

namespace backend.Services.Interfaces
{
    public interface ITechnologyLevelService
    {
        bool AddLevel(TechnologyLevelToCreationDto newLevel);
        TechnologyLevelDto? GetLevel(int levelId);
        ICollection<TechnologyLevelDto>? GetLevels();
        bool UpdateLevel(TechnologyLevel updatedLevel);
        bool DeleteLevel(int deletedLevelId);
    }
}
