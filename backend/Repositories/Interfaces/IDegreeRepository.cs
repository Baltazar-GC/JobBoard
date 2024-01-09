using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface IDegreeRepository
    {
        bool AddDegree(Degree newDegree);
        Degree? GetDegree(int degreeId);
        bool IsDegree(int degreeId);
        ICollection<Degree>? GetDegrees();
        bool UpdateDegree();
        bool DeleteDegree(int deletedDegreeId);
    }
}
