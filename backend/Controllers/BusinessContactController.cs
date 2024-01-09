using AutoMapper;
using backend.Models;
using backend.Models.BusinessContact;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
    public class BusinessContactController : ControllerBase
    {
        private readonly IBusinessContactService _businessContactService;

        public BusinessContactController(IBusinessContactService businessContactService)
        {
            _businessContactService = businessContactService;
        }

        [HttpGet]
        public IActionResult GetBusinessContact()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var contact = _businessContactService.GetBusinessContact(userId);

            if (contact is null)
                return NotFound("No se encontro la informacion de contacto solicitada");

            return Ok(contact);
        }

        [HttpPost]
        public IActionResult AddBusinessContact(BusinessContactToCreationDto newBusinessContact)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            if (newBusinessContact is null)
                return BadRequest("Debes ingresar los datos correctos.");

            var result = _businessContactService.AddBusinessContact(newBusinessContact, userId);

            if (result)
                return NoContent();
            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [HttpPut]
        public IActionResult UpdateBusinessContact(BusinessContactToUpdateDto updateBusinessContact)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            if (updateBusinessContact is null)
                return BadRequest("Debes ingresar los datos correctos.");

            var bExists = _businessContactService.GetBusinessContact(userId);

            if (bExists == null)
                return NotFound("No se encontro el contacto que deseas actualizar");

            var result = _businessContactService.UpdateBusinessContact(updateBusinessContact, userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });


        }

        [HttpDelete]
        public IActionResult DeleteBusinessContact()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId is null)
                return Unauthorized();

            var bExists = _businessContactService.GetBusinessContact(userId);

            if (bExists == null)
                return NotFound("No se encontro el contacto que deseas eliminar");

            var result = _businessContactService.DeleteBusinessContact(userId);

            if (result)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }
    }
}
