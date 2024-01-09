using AutoMapper;
using backend.Entities;
using backend.Models.StudentExtraData;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class StudentExtraDataService : IStudentExtraDataService
    {
        private readonly IMapper _mapper;
        private readonly IStudentExtraDataRepository _StudentExtraDataRepository;

        public StudentExtraDataService(IMapper mapper, IStudentExtraDataRepository StudentExtraDataRepository)
        {
            _mapper = mapper;
            _StudentExtraDataRepository = StudentExtraDataRepository;
        }

        public bool AddStudentExtraData(StudentExtraDataToCreationDto newStudentExtraData, string userId)
        {
            if (newStudentExtraData == null)
                return false;

            var exist = GetStudentExtraData(userId);

            IFormFile file = newStudentExtraData.File;

            long length = file.Length;

            if (length < 0)
                return false;

            using var fileStream = file.OpenReadStream();

            byte[] bytes = new byte[length];

            fileStream.Read(bytes, 0, (int)file.Length);

            var newextradata = new StudentExtraData()
            {
                StudentId = userId,
                Curriculum = bytes,
                HighSchoolDegree = newStudentExtraData.HighSchoolDegree,
                Comments = newStudentExtraData.Comments,
            };


            if (exist == null)
            {
                return _StudentExtraDataRepository.AddStudentExtraData(newextradata);

            }
            return _StudentExtraDataRepository.UpdateStudentExtraData(newextradata);










        }

        public bool DeleteStudentExtraData(string studentId)
        {
            return _StudentExtraDataRepository.DeleteStudentExtraData(studentId);
        }

        public StudentExtraDataDto? GetStudentExtraData(string studentId)
        {
            var infoStudent = _StudentExtraDataRepository.GetStudentExtraData(studentId);

            if (infoStudent is null)
                return null;
            var mapped = _mapper.Map<StudentExtraDataDto>(infoStudent);
            return mapped;
        }



    }
}

