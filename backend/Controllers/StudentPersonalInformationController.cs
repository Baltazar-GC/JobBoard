using backend.Models;
using backend.Models.StudentPersonalInformation;
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
    public class StudentPersonalInformationController : ControllerBase
    {
        private readonly IStudentPersonalInformationService _studentPersonalInformationService;

        public StudentPersonalInformationController(IStudentPersonalInformationService studentPersonalInformationService)
        {
            _studentPersonalInformationService = studentPersonalInformationService;
        }

        [HttpGet]
        public ActionResult GetStudentPersonalInformation()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var info = _studentPersonalInformationService.GetStudentPersonalInformation(userId);

            if (info == null)
                return NotFound("No se encontro la ficha del estudiante solicitado");
            return Ok(info);
        }

        [HttpPost]
        public ActionResult AddStudentPersonalInformation(StudentPersonalInformationToCreationDto newBInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var result = _studentPersonalInformationService.AddStudentPersonalInformation(newBInfo, userId);

            if (result)
                return Ok("Ficha creada con exito!");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [HttpPut]
        public ActionResult UpdateStudentPersonalInformation(StudentPersonalInformationToUpdateDto newBInfo)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();


            var bExists = _studentPersonalInformationService.GetStudentPersonalInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la ficha que deseas actualizar");

            var result = _studentPersonalInformationService.UpdateStudentPersonalInformation(newBInfo, userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });
        }

        [HttpDelete]
        public ActionResult DeleteStudentPersonalInformation()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var bExists = _studentPersonalInformationService.GetStudentPersonalInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la ficha que deseas eliminar");

            var result = _studentPersonalInformationService.DeleteStudentPersonalInformation(userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}
