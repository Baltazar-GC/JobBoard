using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class ApplicationInternship
    {


        [Key]
        public int Id { get; set; }


        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }


        public DateTime ApplyDate { get; set; }

        [ForeignKey("InternshipOffer")]
        public int InternshipOfferId { get; set; }
        public InternshipOffer InternshipOffer { get; set; }
    }
}
