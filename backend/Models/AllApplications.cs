using backend.Models.Application;

namespace backend.Models
{
    public class AllApplications
    {
        public ICollection<ApplicationHiredDto> HiredApplications { get; set; }

        public ICollection<ApplicationInternshipDto> InternshipApplications { get; set; }

    }
}
