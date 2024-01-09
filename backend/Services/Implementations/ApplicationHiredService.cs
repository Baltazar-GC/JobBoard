using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Models.Application;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class ApplicationHiredService : IApplicationHiredService
    {
        private readonly IApplicationHiredRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationHiredService(IApplicationHiredRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }
        public bool Apply(ApplicationHiredToCreationDto application, string studentId)
        {
            var mapped = _mapper.Map<ApplicationHired>(application);

            mapped.StudentId = studentId;

            return _applicationRepository.Apply(mapped);
        }

        public bool CancelApply(int jobOfferId)
        {
            return _applicationRepository.CancelApply(jobOfferId);
        }

        public ICollection<ApplicationHiredDto>? GetApplicationsByHired(int jobOfferId)
        {
            var applications = _applicationRepository.GetApplicationsByJobHired(jobOfferId);

            var mapped = _mapper.Map<ICollection<ApplicationHiredDto>>(applications);

            return mapped;
        }

        public ICollection<ApplicationHiredDto>? GetApplicationsByStudent(string studentId)
        {
            var applications = _applicationRepository.GetApplicationsByStudent(studentId);

            var mapped = _mapper.Map<ICollection<ApplicationHiredDto>>(applications);

            return mapped;
        }

        public PostulantDataDto? GetPostulantData(string studentId)
        {
            var data = _applicationRepository.GetStudentData(studentId);

            if (data is null)
                return null;

            return _mapper.Map<PostulantDataDto>(data);
        }
    }
}
