using backend.Models;
using backend.Models.StudentCollegeInformation;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCollegeInformationController : ControllerBase
    {
        private readonly IStudentCollegeInformationService _studentCollegeInformationService;

        public StudentCollegeInformationController(IStudentCollegeInformationService studentCollegeInformationService)
        {
            _studentCollegeInformationService = studentCollegeInformationService;
        }

        [HttpGet]
        public ActionResult GetStudentCollegeInformation()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var info = _studentCollegeInformationService.GetStudentCollegeInformation(userId);
            if (info == null)
                return NotFound("No se encontro la información universitaria del estudiante solicitida");
            return Ok(info);
        }

        [HttpPost]
        public ActionResult AddStudentCollegeInformation(StudentCollegeInformationToCreationDto newBInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var result = _studentCollegeInformationService.AddStudentCollegeInformation(newBInfo, userId);

            if (result)
                return Ok("información universitaria creada con exito!");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [HttpPut]
        public ActionResult UpdateStudentCollegeInformation(StudentCollegeInformationToUpdateDto newBInfo)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _studentCollegeInformationService.GetStudentCollegeInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la información universitaria que deseas actualizar");

            var result = _studentCollegeInformationService.UpdateStudentCollegeInformation(newBInfo, userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });
        }

        [HttpDelete]
        public ActionResult DeleteStudentCollegeInformation()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _studentCollegeInformationService.GetStudentCollegeInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la información universitaria que deseas eliminar");

            var result = _studentCollegeInformationService.DeleteStudentCollegeInformation(userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}
