using backend.Contexts;
using backend.Entities;
using backend.Repositories.Interfaces;

namespace backend.Repositories.Implementations
{
    public class TechnologyRepository : Repository, ITechnologyRepository
    {
        private readonly ISkillRepository _skillRepository;
        public TechnologyRepository(ApplicationUtnContext context, ISkillRepository skillRepository) : base(context)
        {
            _skillRepository = skillRepository;
        }


        public bool AddTechnology(Technology newTechnology)
        {
            if (newTechnology is null)
                return false;

            _context.Technologies?.Add(newTechnology);




            return SaveChanges();
        }

        public bool DeleteTechnology(int deletedTechnologyId)
        {
            var technology = GetTechnology(deletedTechnologyId);

            if (technology == null)
                return false;

            _context.Technologies?.Remove(technology);


            return SaveChanges();

        }

        public Technology? GetTechnology(int technologyId)
        {
            var tecnologyExist = IsTechnology(technologyId);
            if (tecnologyExist)
                return _context.Technologies?.FirstOrDefault(d => d.TechnologyId == technologyId);
            return null;
        }

        public ICollection<Technology>? GetTechnologies()
        {
            var technologies = _context.Technologies?.ToList();

            if (technologies != null || technologies.Count() > 0)
                return technologies;

            return null;

        }

        public bool IsTechnology(int technologyId)
        {
            var technology = _context.Technologies?.FirstOrDefault(d => d.TechnologyId == technologyId);

            if (technology is null)
                return false;

            return true;
        }

        public bool UpdateTechnology()
        {
            return SaveChanges();
        }
    }
}
