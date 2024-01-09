using AutoMapper;
using backend.Entities;
using backend.Models.Application;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class ApplicationInternshipService : IApplicationInternshipService
    {
        private readonly IApplicationInternshipRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationInternshipService(IApplicationInternshipRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public bool Apply(ApplicationInternshipToCreationDto application, string studentId)
        {
            var mapped = _mapper.Map<ApplicationInternship>(application);

            mapped.StudentId = studentId;

            return _applicationRepository.Apply(mapped);
        }

        public bool CancelApply(int jobOfferId)
        {
            return _applicationRepository.CancelApply(jobOfferId);
        }

        public ICollection<ApplicationInternshipDto>? GetApplicationsByInternship(int jobOfferId)
        {
            var applications = _applicationRepository.GetApplicationsByJobInternship(jobOfferId);

            var mapped = _mapper.Map<ICollection<ApplicationInternshipDto>>(applications);

            return mapped;
        }

        public ICollection<ApplicationInternshipDto>? GetApplicationsByStudent(string studentId)
        {
            var applications = _applicationRepository.GetApplicationsByStudent(studentId);

            var mapped = _mapper.Map<ICollection<ApplicationInternshipDto>>(applications);

            return mapped;
        }
    }
}
