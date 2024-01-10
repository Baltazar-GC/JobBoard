using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IDegreeRepository
    {
        Task<bool> Add(Degree newDegree);

        Task<Degree?> Get(int degreeId);

        Task<ICollection<Degree>> List();

        Task<bool> Update(Degree updatedDegreee);

        Task<bool> Delete(int deletedDegreeId);
    }
}
