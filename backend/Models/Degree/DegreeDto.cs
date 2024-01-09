using backend.Enums;

namespace backend.Models.Degree
{
    public class DegreeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DegreeLevel DegreeLevel { get; set; }
    }
}
