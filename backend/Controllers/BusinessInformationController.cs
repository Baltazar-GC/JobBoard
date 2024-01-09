using backend.Models;
using backend.Models.BusinessInformation;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
    [Route("api/bussinessinformation")]
    [ApiController]
    public class BusinessInformationController : ControllerBase
    {
        private readonly IBusinessInformationService _businessInformationService;

        public BusinessInformationController(IBusinessInformationService businessInformationService)
        {
            _businessInformationService = businessInformationService;
        }

        [HttpGet]
        public ActionResult GetBusinessInformation()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var info = _businessInformationService.GetBusinessInformation(userId);
            if (info == null)
                return NotFound("No se encontro la ficha de empresa solicitada");

            return Ok(info);
        }

        [HttpPost]
        public ActionResult AddBusinessInformation(BusinessInformationToCreationDto newBInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var result = _businessInformationService.AddBusinessInformation(newBInfo, userId);

            if (result)
                return Ok("Ficha creada con exito!");
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [HttpPut]
        public ActionResult UpdateBusinessInformation(BusinessInformationToUpdateDto newBInfo)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _businessInformationService.GetBusinessInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la ficha que deseas actualizar");

            var result = _businessInformationService.UpdateBusinessInformation(newBInfo, userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });
        }

        [HttpDelete]
        public ActionResult DeleteBusinessInformation()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _businessInformationService.GetBusinessInformation(userId);

            if (bExists == null)
                return NotFound("No se encontro la ficha que deseas eliminar");

            var result = _businessInformationService.DeleteBusinessInformation(userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

    }
}
