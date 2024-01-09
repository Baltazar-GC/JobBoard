using System.ComponentModel.DataAnnotations;

namespace backend.Entities
{
    public class Employer : User
    {
        public string Description { get; set; } = string.Empty;

        public virtual BusinessInformation BusinessInformation { get; set; }
        public virtual BusinessContact BusinessContact { get; set; }


        public virtual ICollection<InternshipOffer> InternshipOffers { get; set; }
        public virtual ICollection<HiredEmployeeOffer> HiredEmployeeOffers { get; set; }

    }
}
