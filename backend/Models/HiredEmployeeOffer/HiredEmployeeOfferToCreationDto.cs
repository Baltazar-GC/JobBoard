using System.ComponentModel.DataAnnotations;

namespace backend.Models.HiredEmployeeOffer
{
    public class HiredEmployeeOfferToCreationDto
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

        [Required, StringLength(25)]
        public string WorkingHours { get; set; } = string.Empty;


    }
}
