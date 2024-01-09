using System.ComponentModel.DataAnnotations;

namespace backend.Models.InternshipOffer
{
    public class InternshipOfferToCreationDto
    {

        [Required]
        public string EmailReceiver { get; set; } = string.Empty;

        [Required]
        public DateTime InitialDate { get; set; }

        [Required]
        public DateTime FinalDate { get; set; }


        [Required]
        public int PositionsToFill { get; set; }


        [Required]
        public string Title { get; set; } = string.Empty;


        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string WorkLocation { get; set; } = string.Empty;

        public int DegreeId { get; set; }


        [Required]
        public bool HasAnAgreement { get; set; }

        [Required]
        [Range(2, 12)]
        public int MonthsOfDuration { get; set; }

        //no tiene required en la entidad
        public DateTime StartDate { get; set; }




    }
}
