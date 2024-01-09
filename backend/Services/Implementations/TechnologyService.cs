using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyRepository _techRepository;

        public TechnologyService(IMapper mapper, ITechnologyRepository techRepository)
        {
            _mapper = mapper;
            _techRepository = techRepository;
        }
        public bool AddTechnology(TechnologyToCreationDto newTech)
        {
            if (newTech is null)
                return false;

            Technology techMapped = _mapper.Map<Technology>(newTech);

            return _techRepository.AddTechnology(techMapped);
        }

        public bool DeleteTechnology(int deletedTechnologyId)
        {
            return _techRepository.DeleteTechnology(deletedTechnologyId);
        }

        public TechnologyDto? GetTechnology(int technologyId)
        {
            var technology = _techRepository.GetTechnology(technologyId);

            if (technology == null)
                return null;

            return _mapper.Map<TechnologyDto>(technology);
        }

        public ICollection<TechnologyDto>? GetTechnologies()
        {
            var technologies = _techRepository.GetTechnologies();
            if (technologies == null)
                return null;
            return _mapper.Map<ICollection<TechnologyDto>>(technologies);
        }


        public bool UpdateTechnology(TechnologyToUpdateDto updatedTechnology, int technologyLevelId)
        {
            if (updatedTechnology == null)
                return false;

            var levelToUpdate = _techRepository.GetTechnology(technologyLevelId);

            if (levelToUpdate == null)
                return false;

            _mapper.Map(updatedTechnology, levelToUpdate);
            return _techRepository.UpdateTechnology();

        }
    }
}
