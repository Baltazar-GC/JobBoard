using backend.Models.TechnologyLevel;

namespace backend.Services.Interfaces
{
    public interface ITechnologyLevelService
    {
        bool AddLevel(TechnologyLevelToCreationDto newLevel);
        TechnologyLevelDto? GetLevel(int levelId);
        ICollection<TechnologyLevelDto>? GetLevels();
        bool UpdateLevel(TechnologyLevelToUpdateDto updatedLevel, int levelId);
        bool DeleteLevel(int deletedLevelId);
    }
}
