using backend.Entities;
using backend.Models.Degree;

namespace backend.Models.InternshipOffer
{
    public class InternshipOfferDto
    {
        public int Id { get; set; }

        public string EmailReceiver { get; set; } = string.Empty;

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public int PositionsToFill { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string WorkLocation { get; set; } = string.Empty;

        public int DegreeId { get; set; }

        public virtual DegreeDto Degree { get; set; } //dejamos esta?

        public bool HasAnAgreement { get; set; }

        public int MonthsOfDuration { get; set; }

        public DateTime StartDate { get; set; }

        public string EmployerId { get; set; }
        public bool IsApproved { get; set; }

    }
}
