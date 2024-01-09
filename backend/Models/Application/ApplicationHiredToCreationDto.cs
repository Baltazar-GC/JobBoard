using System.ComponentModel.DataAnnotations;

namespace backend.Models.Application
{
    public class ApplicationHiredToCreationDto
    {
        [Required]
        public int HiredEmployeeOfferId { get; set; }
    }
}
