using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class BusinessInformation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; } = string.Empty;

        public virtual Employer Employer { get; set; }



        [Required]
        public string BusinessName { get; set; } = string.Empty;

        [Required]
        public string Cuit { get; set; } = string.Empty;

        [Required]
        public string LineOfBusiness { get; set; } = string.Empty;

        [Required]
        public string LegalAddress { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        public string PhoneNumer { get; set; } = string.Empty;

        public string Web { get; set; } = string.Empty;

    }

}
