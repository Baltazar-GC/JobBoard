namespace backend.Models.StudentExtraData
{
    public class StudentExtraDataToUpdateDto
    {
        public IFormFile File { get; set; } //La propiedad donde va a venir el archivo.
        //public byte[]? Curriculum { get; set; } //La propiedad donde va a venir el archivo.

        public string HighSchoolDegree { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
    }
}
