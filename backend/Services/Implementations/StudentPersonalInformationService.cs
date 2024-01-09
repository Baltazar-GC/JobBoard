using AutoMapper;
using backend.Entities;
using backend.Models.StudentPersonalInformation;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class StudentPersonalInformationService : IStudentPersonalInformationService
    {
        private readonly IMapper _mapper;
        private readonly IStudentPersonalInformationRepository _studentPersonalInformationRepository;

        public StudentPersonalInformationService(IMapper mapper, IStudentPersonalInformationRepository studentPersonalInformationRepository)
        {
            _mapper = mapper;
            _studentPersonalInformationRepository = studentPersonalInformationRepository;
        }

        public bool AddStudentPersonalInformation(StudentPersonalInformationToCreationDto newStudentPersonalInformation, string userId)
        {
            if (newStudentPersonalInformation == null)
                return false;
            StudentPersonalInformation mapped = _mapper.Map<StudentPersonalInformation>(newStudentPersonalInformation);
            mapped.StudentId = userId;

            return _studentPersonalInformationRepository.AddStudentPersonalInformation(mapped);
        }

        public bool DeleteStudentPersonalInformation(string studentId)
        {
            return _studentPersonalInformationRepository.DeleteStudentPersonalInformation(studentId);
        }

        public StudentPersonalInformationDto? GetStudentPersonalInformation(string studentId)
        {
            var infoStudent = _studentPersonalInformationRepository.GetStudentPersonalInformation(studentId);

            if (infoStudent is null)
                return null;
            var mapped = _mapper.Map<StudentPersonalInformationDto>(infoStudent);
            return mapped;
        }


        public bool UpdateStudentPersonalInformation(StudentPersonalInformationToUpdateDto updatedStudentPersonalInformation, string studentId)
        {
            if (updatedStudentPersonalInformation == null)
                return false;

            var studentPersonalInformationToUpdate = _studentPersonalInformationRepository.GetStudentPersonalInformation(studentId);

            if (studentPersonalInformationToUpdate == null)
                return false;

            _mapper.Map(updatedStudentPersonalInformation, studentPersonalInformationToUpdate);

            return _studentPersonalInformationRepository.UpdateStudentPersonalInformation();
        }
    }
}
