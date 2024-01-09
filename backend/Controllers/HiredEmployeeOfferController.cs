using backend.Models;
using backend.Models.HiredEmployeeOffer;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/hired-employee-offers")]
    [ApiController]
    public class HiredEmployeeOfferController : ControllerBase
    {
        private readonly IHiredEmployeeOfferService _HiredEmployeeOfferService;

        public HiredEmployeeOfferController(IHiredEmployeeOfferService HiredEmployeeOfferService)
        {
            _HiredEmployeeOfferService = HiredEmployeeOfferService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        public ActionResult<ICollection<HiredEmployeeOfferDto>> GetAll()
        {
            var offers = _HiredEmployeeOfferService.GetAll();

            if (offers is null)
                return NotFound("No se encontraron ofertas publicadas");

            return Ok(offers);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        [Route("{HiredEmployeeOfferId}")]
        public ActionResult<HiredEmployeeOfferDto> GetHiredEmployeeOffer(int HiredEmployeeOfferId)
        {
            var offer = _HiredEmployeeOfferService.GetHiredEmployeeOffer(HiredEmployeeOfferId);

            if (offer is null)
                return NotFound("No se encontro la oferta solicitada");

            return Ok(offer);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
        [Route("myHiredEmployeeOffers")]
        public ActionResult<ICollection<HiredEmployeeOfferDto>> GetAllByEmployer()
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;



            if (userId == null)
                return Unauthorized();

            var offers = _HiredEmployeeOfferService.GetAllByEmployerId(userId);

            if (offers is null)
                return NotFound("No se encontraron ofertas publicadas en esta empresa");

            return Ok(offers);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
        [Route("myHiredEmployeeOffers/{HiredEmployeeOfferId}")]
        public ActionResult<ICollection<HiredEmployeeOfferDto>> GetHiredEmployeeOfferEmployer(int HiredEmployeeOfferId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var offer = _HiredEmployeeOfferService.GetHiredEmployeeOfferByEmployerId(userId, HiredEmployeeOfferId);

            if (offer is null)
                return NotFound("No se encontraron ofertas publicadas en esta empresa");

            return Ok(offer);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ApprovedEmployer")]
        public IActionResult AddHiredEmployeeOffer(HiredEmployeeOfferToCreationDto newOffer)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var result = _HiredEmployeeOfferService.AddHiredEmployeeOffer(newOffer, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ApprovedEmployer")]
        [Route("{HiredEmployeeOfferId}")]
        public IActionResult UpdateHiredEmployeeOffer(HiredEmployeeOfferToUpdateDto updatedOffer, int HiredEmployeeOfferId)
        {
            var result = _HiredEmployeeOfferService.UpdateHiredEmployeeOffer(updatedOffer, HiredEmployeeOfferId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, ApprovedEmployer")]
        [Route("{HiredEmployeeOfferId}")]
        public IActionResult DeleteHiredEmployeeOffer(int HiredEmployeeOfferId)
        {
            var result = _HiredEmployeeOfferService.DeleteHiredEmployeeOffer(HiredEmployeeOfferId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }




    }
}
