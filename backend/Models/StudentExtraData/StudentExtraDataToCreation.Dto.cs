using System.ComponentModel.DataAnnotations;

namespace backend.Models.StudentExtraData
{
    public class StudentExtraDataToCreationDto
    {
        [Required(ErrorMessage = "Debes ingresar un curriculum")]
        public IFormFile File { get; set; } //La propiedad donde va a venir el archivo.
        //public byte[]? Curriculum { get; set; } //La propiedad donde va a venir el archivo.

        public string HighSchoolDegree { get; set; } = string.Empty;

        public string Comments { get; set; } = string.Empty;
    }
}
