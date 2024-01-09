using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class TechnologyLevel
    {
        [Key]
        public int TechnologyLevelId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
