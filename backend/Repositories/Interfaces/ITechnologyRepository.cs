using backend.Entities;

namespace backend.Repositories.Interfaces
{
    public interface ITechnologyRepository
    {
        bool AddTechnology(Technology newTechnology);
        Technology? GetTechnology(int technologyId);
        bool IsTechnology(int technologyId);
        ICollection<Technology>? GetTechnologies();
        bool UpdateTechnology();
        bool DeleteTechnology(int technologyDeletedId);
    }

}
