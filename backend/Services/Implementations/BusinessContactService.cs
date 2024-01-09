using AutoMapper;
using backend.Entities;
using backend.Models.BusinessContact;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;

namespace backend.Services.Implementations
{
    public class BusinessContactService : IBusinessContactService
    {
        private readonly IMapper _mapper;
        private readonly IBusinessContactRepository _businessContactRepository;

        public BusinessContactService(IMapper mapper, IBusinessContactRepository businessContactRepository)
        {
            _mapper = mapper;
            _businessContactRepository = businessContactRepository;
        }

        public bool AddBusinessContact(BusinessContactToCreationDto newBusinessContact, string employerId)
        {
            BusinessContact mapped = _mapper.Map<BusinessContact>(newBusinessContact);

            mapped.EmployerId = employerId;

            return _businessContactRepository.AddBusinessContact(mapped);
        }

        public bool DeleteBusinessContact(string employerId)
        {
            return _businessContactRepository.DeleteBusinessContact(employerId);
        }

        public BusinessContactDto GetBusinessContact(string employerId)
        {
            var contact = _businessContactRepository.GetBusinessContact(employerId);

            if (contact is null)
                return null;

            var mapped = _mapper.Map<BusinessContactDto>(contact);

            return mapped;
        }


        public bool UpdateBusinessContact(BusinessContactToUpdateDto updatedBusinessContact, string employerId)
        {
            if (updatedBusinessContact == null)
                return false;

            var businessToUpdate = _businessContactRepository.GetBusinessContact(employerId);

            if (businessToUpdate == null)
                return false;

            _mapper.Map(updatedBusinessContact, businessToUpdate);

            return _businessContactRepository.UpdateBusinessContact();
        }
    }
}
