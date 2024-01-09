using backend.Entities;
using backend.Models.BusinessContact;
using backend.Models.BusinessInformation;

namespace backend.Models
{
    public class EmployerToApproveDto
    {
        public User Employer { get; set; }
        public BusinessContactDto BusinessContact { get; set; }
        public BusinessInformationDto BusinessInformation { get; set; }

    }
}
