using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public abstract class JobOffer
    {
        [Key]
        public int Id { get; set; }

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


        [ForeignKey("Degree")]
        public int DegreeId { get; set; }

        public virtual Degree Degree { get; set; }



    }
}
