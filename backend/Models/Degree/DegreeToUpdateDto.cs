using System.ComponentModel.DataAnnotations;
using backend.Enums;

namespace backend.Models.Degree
{
    public class DegreeToUpdateDto
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DegreeLevel DegreeLevel { get; set; }
    }
}
