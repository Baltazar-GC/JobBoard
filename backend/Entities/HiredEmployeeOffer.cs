using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class HiredEmployeeOffer : JobOffer
    {
        [Required, StringLength(25)]
        public string WorkingHours { get; set; } = string.Empty;

        [ForeignKey("Employer")]
        public string EmployerId { get; set; }

        public virtual Employer Employer { get; set; }
    }
}
