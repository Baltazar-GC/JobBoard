using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Entities
{
    public class Technology
    {
        [Key]
        public int TechnologyId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;

        public ICollection<Skill> Skills { get; set; }

    }
}
