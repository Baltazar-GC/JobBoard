using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class TechnologyToUpdateDto
    {
        [Required]
        public int Id { get; set; }
    
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
