using AutoMapper;
using backend.Entities;
using backend.Models.Degree;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class DegreeService : IDegreeService
    {
        private readonly IMapper _mapper;
        private readonly IDegreeRepository _degreeRepository;

        public DegreeService(IMapper mapper, IDegreeRepository degreeRepository)
        {
            _mapper = mapper;
            _degreeRepository = degreeRepository;
        }
        public bool AddDegree(DegreeToCreationDto newDegree)
        {
            if (newDegree is null)
                return false;

            Degree degreeMapped = _mapper.Map<Degree>(newDegree);

            return _degreeRepository.AddDegree(degreeMapped);
        }

        public bool DeleteDegree(int deletedDegreeId)
        {
            return _degreeRepository.DeleteDegree(deletedDegreeId);
        }

        public DegreeDto? GetDegree(int degreeId)
        {
            var degree = _degreeRepository.GetDegree(degreeId);

            if (degree == null)
                return null;

            return _mapper.Map<DegreeDto>(degree);
        }

        public ICollection<DegreeDto>? GetDegrees()
        {
            var degrees = _degreeRepository.GetDegrees();
            if (degrees == null || degrees.Count() <= 0)
                return null;
            return _mapper.Map<ICollection<DegreeDto>>(degrees);
        }


        public bool UpdateDegree(DegreeToUpdateDto updatedDegree, int degreeId)
        {
            if (updatedDegree == null)
                return false;

            var degreeToUpdate = _degreeRepository.GetDegree(degreeId);

            if (degreeToUpdate == null)
                return false; ;

            _mapper.Map(updatedDegree, degreeToUpdate);
            return _degreeRepository.UpdateDegree();

        }
    }
}
