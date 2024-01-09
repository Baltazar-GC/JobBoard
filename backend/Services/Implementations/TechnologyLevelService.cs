using AutoMapper;
using backend.Entities;
using backend.Models.TechnologyLevel;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class TechnologyLevelService : ITechnologyLevelService
    {
        private readonly IMapper _mapper;
        private readonly ITechnologyLevelRepository _levelRepository;

        public TechnologyLevelService(IMapper mapper, ITechnologyLevelRepository levelRepository)
        {
            _mapper = mapper;
            _levelRepository = levelRepository;
        }
        public bool AddLevel(TechnologyLevelToCreationDto newLevel)
        {
            TechnologyLevel levelMapped = _mapper.Map<TechnologyLevel>(newLevel);

            return _levelRepository.AddLevel(levelMapped);
        }

        public bool DeleteLevel(int deletedLevelId)
        {
            return _levelRepository.DeleteLevel(deletedLevelId);
        }

        public TechnologyLevelDto? GetLevel(int levelId)
        {
            var level = _levelRepository.GetLevel(levelId);

            if (level == null)
                return null;

            return _mapper.Map<TechnologyLevelDto>(level);
        }

        public ICollection<TechnologyLevelDto>? GetLevels()
        {
            var levels = _levelRepository.GetLevels();
            if (levels == null)
                return null;
            return _mapper.Map<ICollection<TechnologyLevelDto>>(levels);
        }


        public bool UpdateLevel(TechnologyLevelToUpdateDto updatedLevel, int levelId)
        {
            if (updatedLevel == null)
                return false;

            var levelToUpdate = _levelRepository.GetLevel(levelId);

            if (levelToUpdate == null)
                return false;

            _mapper.Map(updatedLevel, levelToUpdate);

            return _levelRepository.UpdateLevel();

        }
    }
}
