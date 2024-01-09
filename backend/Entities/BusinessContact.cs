using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace backend.Entities
{
    public class BusinessContact
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Employer")]
        public string EmployerId { get; set; } = string.Empty;

        public virtual Employer Employer { get; set; }



        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required]
        public string SecondaryPhone { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool IsAnEmployee { get; set; }

    }

}

