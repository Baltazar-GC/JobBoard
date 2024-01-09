using backend.Models;

namespace backend.Services.Interfaces
{
    public interface ITechnologyService
    {

        bool AddTechnology(TechnologyToCreationDto newTechnology);
        TechnologyDto? GetTechnology(int technologyId);
        ICollection<TechnologyDto>? GetTechnologies();
        bool UpdateTechnology(TechnologyToUpdateDto updatedTechnology, int technologyId);
        bool DeleteTechnology(int technologyId);
    }
}
