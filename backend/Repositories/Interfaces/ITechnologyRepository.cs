using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface ITechnologyRepository
    {
        Task<bool> Add(Technology newTechnology);

        Task<Technology?> Get(int technologyId);

        Task<ICollection<Technology>> List();

        Task<bool> Update(Technology updatedTechnology);
        
        Task<bool> Delete(int technologyDeletedId);
    }

}
