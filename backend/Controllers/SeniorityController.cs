using backend.Models;
using backend.Models.TechnologyLevel;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/levels")]
    [ApiController]
    public class SeniorityController : ControllerBase
    {
        private readonly ITechnologyLevelService _levelService;


        public SeniorityController(ITechnologyLevelService levelService)
        {
            _levelService = levelService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        [HttpGet]
        public ActionResult<ICollection<TechnologyLevelDto>> GetLevels()
        {

            var levels = _levelService.GetLevels();

            if (levels == null)
                return NotFound("No se encontraron niveles de seniority cargados.");


            return Ok(levels);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        [HttpGet("{levelId}")]
        public ActionResult<TechnologyLevelDto> GetLevel(int levelId)
        {


            var level = _levelService.GetLevel(levelId);



            if (level is null)
                return NotFound("No se encontro el nivel de seniority.");


            return Ok(level);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult AddLevel(TechnologyLevelToCreationDto levelToCreationDto)
        {

            if (levelToCreationDto == null)
                return BadRequest("Debes enviar los campos correctos.");

            var result = _levelService.AddLevel(levelToCreationDto);

            if (result)
                return Ok("Nivel de seniority creado con exito!");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }


        [HttpPut("{levelId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult UpdateLevel(TechnologyLevelToUpdateDto levelToUpdateDto, int levelId)
        {


            if (levelToUpdateDto == null)
                return BadRequest("Debes enviar los campos correctos.");

            var levelExist = _levelService.GetLevel(levelId);

            if (levelExist == null)
                return NotFound("No se encontro el nivel de seniority que intentas actualizar.");


            var result = _levelService.UpdateLevel(levelToUpdateDto, levelId);

            if (result)
                return Ok("Nivel de seniority actualizado con exito!");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [HttpDelete("{levelId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult DeleteLevel(int levelId)
        {

            var levelExist = _levelService.GetLevel(levelId);

            if (levelExist == null)
                return NotFound("No se encontro el nivel de seniority que buscas eliminar");

            var result = _levelService.DeleteLevel(levelId);

            if (result)
                return Ok("Nivel de seniority eliminado con exito.");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}
