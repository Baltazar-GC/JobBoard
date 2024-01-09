using backend.Models;
using backend.Models.StudentExtraData;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentExtraDataController : ControllerBase
    {
        private readonly IStudentExtraDataService _StudentExtraDataService;

        public StudentExtraDataController(IStudentExtraDataService StudentExtraDataService)
        {
            _StudentExtraDataService = StudentExtraDataService;
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
        [HttpGet("DownloadCV/{studentId}")]
        public async Task<IActionResult> GetCurriculum(string studentId)
        {

            if (studentId is null)
            {
                return NotFound();
            }

            var info = _StudentExtraDataService.GetStudentExtraData(studentId);


            if (info.Curriculum is null)
            {
                return BadRequest();
            }

            return File(info.Curriculum, "application/pdf", $"asd_CV.pdf");
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpGet("DownloadCV")]
        public async Task<IActionResult> GetCurriculum()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
            {
                return NotFound();
            }

            var info = _StudentExtraDataService.GetStudentExtraData(userId);


            if (info.Curriculum is null)
            {
                return BadRequest();
            }

            return File(info.Curriculum, "application/pdf", $"asd_CV.pdf");
        }
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpPut]
        public ActionResult AddStudentExtraData([FromForm] StudentExtraDataToCreationDto newBInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();


            var result = _StudentExtraDataService.AddStudentExtraData(newBInfo, userId);

            if (result)
                return Ok("Datos extra creados con exito!");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpDelete]
        public ActionResult DeleteStudentExtraData()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _StudentExtraDataService.GetStudentExtraData(userId);

            if (bExists == null)
                return NotFound("No se encontraron los datos solicitados del estudiante que deseas eliminar");

            var result = _StudentExtraDataService.DeleteStudentExtraData(userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}