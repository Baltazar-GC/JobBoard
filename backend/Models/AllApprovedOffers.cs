using backend.Models.InternshipOffer;

namespace backend.Models
{
    public class AllApprovedOffers
    {
        public ICollection<InternshipOfferDto> Internships { get; set; }
        public ICollection<HiredEmployeeOfferDto> HiredEmployeeOffers { get; set; }

    }
}
