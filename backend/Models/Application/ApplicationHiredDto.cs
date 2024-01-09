using backend.Entities;

namespace backend.Models.Application
{
    public class ApplicationHiredDto
    {
        public int Id { get; set; }


        public string StudentId { get; set; }
        public Student Student { get; set; }



        public int HiredEmployeeOfferId { get; set; }
        public HiredEmployeeOfferDto HiredEmployeeOffer { get; set; }

        public DateTime ApplyDate { get; set; }

    }
}
