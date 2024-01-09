using AutoMapper;
using backend.Entities;
using backend.Models.StudentCollegeInformation;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class StudentCollegeInformationService : IStudentCollegeInformationService
    {
        private readonly IMapper _mapper;
        private readonly IStudentCollegeInformationRepository _studentCollegeInformationRepository;

        public StudentCollegeInformationService(IMapper mapper, IStudentCollegeInformationRepository studentCollegeInformationRepository)
        {
            _mapper = mapper;
            _studentCollegeInformationRepository = studentCollegeInformationRepository;
        }

        public bool AddStudentCollegeInformation(StudentCollegeInformationToCreationDto newStudentCollegeInformation, string userId)
        {
            if (newStudentCollegeInformation == null)
                return false;
            StudentCollegeInformation mapped = _mapper.Map<StudentCollegeInformation>(newStudentCollegeInformation);

            mapped.StudentId = userId;

            return _studentCollegeInformationRepository.AddStudentCollegeInformation(mapped);
        }

        public bool DeleteStudentCollegeInformation(string studentId)
        {
            return _studentCollegeInformationRepository.DeleteStudentCollegeInformation(studentId);
        }

        public StudentCollegeInformationDto? GetStudentCollegeInformation(string studentId)
        {
            var infoStudent = _studentCollegeInformationRepository.GetStudentCollegeInformation(studentId);

            if (infoStudent is null)
                return null;
            var mapped = _mapper.Map<StudentCollegeInformationDto>(infoStudent);
            return mapped;
        }


        public bool UpdateStudentCollegeInformation(StudentCollegeInformationToUpdateDto updatedStudentCollegeInformation, string studentId)
        {
            if (updatedStudentCollegeInformation == null)
                return false;

            var studentCollegeInformationToUpdate = _studentCollegeInformationRepository.GetStudentCollegeInformation(studentId);

            if (studentCollegeInformationToUpdate == null)
                return false;

            _mapper.Map(updatedStudentCollegeInformation, studentCollegeInformationToUpdate);

            return _studentCollegeInformationRepository.UpdateStudentCollegeInformation();
        }
    }
}
