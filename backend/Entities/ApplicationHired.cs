using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class ApplicationHired
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public Student Student { get; set; }


        public DateTime ApplyDate { get; set; }

        [ForeignKey("HiredEmployeeOffer")]
        public int HiredEmployeeOfferId { get; set; }
        public HiredEmployeeOffer HiredEmployeeOffer { get; set; }
    }
}
