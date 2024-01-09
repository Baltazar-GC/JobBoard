using backend.Entities;

namespace backend.Models.InternshipOffer
{
    public class InternshipOfferToUpdateDto
    {


        public string EmailReceiver { get; set; } = string.Empty;

        public DateTime InitialDate { get; set; }

        public DateTime FinalDate { get; set; }

        public int PositionsToFill { get; set; }


        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        public string WorkLocation { get; set; } = string.Empty;
        public int DegreeId { get; set; }

        //public virtual Degree Degree { get; set; } //lo dejé


        public bool HasAnAgreement { get; set; }


        public int MonthsOfDuration { get; set; }

        //no tiene required
        public DateTime StartDate { get; set; }



    }
}
