using backend.Models;
using backend.Models.Degree;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("api/degrees")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeService _degreeService;


        public DegreesController(IDegreeService degreeService)
        {
            _degreeService = degreeService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer, ApprovedEmployer")]
        [HttpGet]
        public ActionResult<ICollection<DegreeDto>> GetDegrees()
        {

            var degrees = _degreeService.GetDegrees();

            if (degrees == null || degrees.Count() <= 0)
                return NotFound("No se encontraron carreras cargadas");


            return Ok(degrees);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer, ApprovedEmployer")]
        [HttpGet("{degreeId}")]
        public ActionResult<DegreeDto> GetLevel(int degreeId)
        {


            var degree = _degreeService.GetDegree(degreeId);



            if (degree is null)
                return NotFound("Carrera no encontrada.");


            return Ok(degree);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost]
        public ActionResult AddDegree(DegreeToCreationDto degreeToCreationDto)
        {

            if (degreeToCreationDto == null)
                return BadRequest("Debes ingresar los campos correctos.");

            var result = _degreeService.AddDegree(degreeToCreationDto);

            if (result)
                return Ok("Carrera creada con exito!");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPut("{degreeId}")]
        public ActionResult UpdateDegree(DegreeToUpdateDto degreeToUpdateDto, int degreeId)
        {


            if (degreeToUpdateDto == null)
                return BadRequest();

            var degreeExist = _degreeService.GetDegree(degreeId);

            if (degreeExist == null)
                return NotFound("No se encontro la carrera que deseas actualizar");


            var result = _degreeService.UpdateDegree(degreeToUpdateDto, degreeId);

            if (result)
                return Ok("Carrera actualizada con exito!");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete("{degreeId}")]
        public ActionResult DeleteDegree(int degreeId)
        {

            var degreeExist = _degreeService.GetDegree(degreeId);

            if (degreeExist == null)
                return NotFound("No se encontro la carrera que deseas eliminar");

            var result = _degreeService.DeleteDegree(degreeId);

            if (result)
                return Ok("Carrera eliminada con exito.");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}
