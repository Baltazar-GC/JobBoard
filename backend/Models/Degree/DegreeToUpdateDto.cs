using backend.Enums;

namespace backend.Models.Degree
{
    public class DegreeToUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public DegreeLevel DegreeLevel { get; set; }
    }
}
