using AutoMapper;
using backend.Entities;
using backend.Models.BusinessInformation;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class BusinessInformationService : IBusinessInformationService
    {
        private readonly IMapper _mapper;
        private readonly IBusinessInformationRepository _businessInformationRepository;

        public BusinessInformationService(IMapper mapper, IBusinessInformationRepository businessInformationRepository)
        {
            _mapper = mapper;
            _businessInformationRepository = businessInformationRepository;
        }

        public bool AddBusinessInformation(BusinessInformationToCreationDto newBusinessInformation, string userId)
        {
            if (newBusinessInformation == null)
                return false;

            BusinessInformation mapped = _mapper.Map<BusinessInformation>(newBusinessInformation);

            mapped.EmployerId = userId;

            return _businessInformationRepository.AddBusinessInformation(mapped);
        }

        public bool DeleteBusinessInformation(string employerId)
        {
            return _businessInformationRepository.DeleteBusinessInformation(employerId);
        }

        public BusinessInformationDto? GetBusinessInformation(string employerId)
        {
            var info = _businessInformationRepository.GetBusinessInformation(employerId);

            if (info == null)
                return null;

            var mapped = _mapper.Map<BusinessInformationDto>(info);

            return mapped;
        }


        public bool UpdateBusinessInformation(BusinessInformationToUpdateDto updatedBusinessInformation, string employerId)
        {
            if (updatedBusinessInformation == null)
                return false;

            var businessToUpdate = _businessInformationRepository.GetBusinessInformation(employerId);

            if (businessToUpdate == null)
                return false;

            _mapper.Map(updatedBusinessInformation, businessToUpdate);

            return _businessInformationRepository.UpdateBusinessInformation();
        }
    }
}
