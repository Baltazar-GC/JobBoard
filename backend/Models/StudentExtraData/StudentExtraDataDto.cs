namespace backend.Models.StudentExtraData
{
    public class StudentExtraDataDto
    {
        public string StudentId { get; set; } = string.Empty;
        public byte[]? Curriculum { get; set; } //La propiedad donde va a venir el archivo.
        public string HighSchoolDegree { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;

    }
}
