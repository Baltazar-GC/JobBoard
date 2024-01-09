using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class InternshipOffer : JobOffer
    {
        [Required]
        public bool HasAnAgreement { get; set; }

        [Required]
        [Range(2, 12)]
        public int MonthsOfDuration { get; set; }

        //no tiene required
        public DateTime StartDate { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }

        public virtual Employer Employer { get; set; }


        [Required]
        public bool IsApproved { get; set; }

        public ICollection<ApplicationHired> HiredApplications { get; set; }

        public ICollection<ApplicationInternship> InternshipApplications { get; set; }

    }
}
