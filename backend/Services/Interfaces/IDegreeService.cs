using backend.Entities;
using backend.Models.Degree;

namespace backend.Services.Interfaces
{
    public interface IDegreeService
    {
        bool AddDegree(DegreeToCreationDto newDegree);
        DegreeDto? GetDegree(int degreeId);
        ICollection<DegreeDto>? GetDegrees();
        bool UpdateDegree(DegreeToUpdateDto updatedDegree, int degreeId);
        bool DeleteDegree(int deletedDegreeId);
    }
}
