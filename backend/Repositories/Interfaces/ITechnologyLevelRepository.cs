using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface ITechnologyLevelRepository
    {
        Task<bool> Add(TechnologyLevel newLevel);

        Task<TechnologyLevel?> Get(int levelId);

        Task<ICollection<TechnologyLevel>> List();

        Task<bool> Update(TechnologyLevel technologyLevel);

        Task<bool> Delete(int deletedLevelId);
    }
}
