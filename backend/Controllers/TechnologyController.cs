using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/Technologies")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyService technologyService;

        public TechnologyController(ITechnologyService technologyService)
        {
            this.technologyService = technologyService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        [HttpGet]
        public ActionResult<ICollection<TechnologyDto>> GetTechnologies()
        {

            var technologies = this.technologyService.GetTechnologies();

            if (technologies == null)
                return NotFound("No se encontraron tecnologias cargadas en el sistema.");


            return Ok(technologies);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        [HttpGet("{technologyId}")]
        public ActionResult<TechnologyDto> GetTechnology(int technologyId)
        {
            var technology = this.technologyService.GetTechnology(technologyId);

            if (technology is null)
                return NotFound("No se encontro la tecnologia buscada");

            return Ok(technology);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPost]
        public ActionResult AddTechnology(TechnologyToCreationDto techToCreationDto)
        {
            if (techToCreationDto == null)
                return BadRequest("Ingrese los campos correctos");

            var result = this.technologyService.AddTechnology(techToCreationDto);

            if (result)
                return Ok("Technology created successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpPut("{technologyId}")]
        public ActionResult UpdateLevel(TechnologyToUpdateDto techToUpdateDto, int technologyId)
        {
            if (techToUpdateDto == null)
                return BadRequest("Ingrese los campos correctos.");

            var techExist = this.technologyService.GetTechnology(technologyId);

            if (techExist == null)
                return NotFound("No se encontro la tecnologia que desea actualizar.");

            var result = this.technologyService.UpdateTechnology(techToUpdateDto, technologyId);
            if (result)
                return Ok("Tecnologia actualizada correctamente.");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpDelete("{technologyId}")]
        public ActionResult DeleteTechnology(int technologyId)
        {
            var techExist = this.technologyService.GetTechnology(technologyId);

            if (techExist == null)
                return NotFound("No se encontro la tecnologia que desea eliminar");

            var result = this.technologyService.DeleteTechnology(technologyId);

            if (result)
                return Ok("Tecnologia eliminada correctamente.");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

    }
}
