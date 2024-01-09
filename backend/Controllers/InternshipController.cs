using backend.Models;
using backend.Models.InternshipOffer;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/internships")]
    [ApiController]
    public class InternshipController : ControllerBase
    {
        private readonly IInternshipService _internshipService;

        public InternshipController(IInternshipService internshipService)
        {
            _internshipService = internshipService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public ActionResult<ICollection<InternshipOfferDto>> GetAll()
        {
            var offers = _internshipService.GetAll();

            if (offers is null)
                return NotFound("No se encontraron pasantias publicadas");

            return Ok(offers);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [Route("{internshipId}")]
        public ActionResult<InternshipOfferDto> GetInternshipOffer(int internshipId)
        {
            var offer = _internshipService.GetInternshipOffer(internshipId);

            if (offer is null)
                return NotFound("No se encontro la pasantia solicitada");

            return Ok(offer);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
        [Route("myinternshipoffers")]
        public ActionResult<ICollection<InternshipOfferDto>> GetAllByEmployer()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var offers = _internshipService.GetAllByEmployerId(userId);

            if (offers is null)
                return NotFound("No se encontraron pasantias publicadas en esta empresa");

            return Ok(offers);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]
        [Route("myinternshipoffers/{internshipId}")]
        public ActionResult<ICollection<InternshipOfferDto>> GetInternshipOfferEmployer(int internshipId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var offer = _internshipService.GetInternshipOfferByEmployerId(userId, internshipId);

            if (offer is null)
                return NotFound("No se encontraron pasantias publicadas en esta empresa");

            return Ok(offer);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer, Admin, Student")]
        [Route("approved")]
        public ActionResult<ICollection<InternshipOfferDto>> GetApprovedInternshipOffers()
        {


            var offers = _internshipService.GetApprovedIntenships();

            if (offers is null)
                return NotFound("No se encontraron pasantias publicadas");

            return Ok(offers);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ApprovedEmployer")]
        public IActionResult AddInternshipOffer(InternshipOfferToCreationDto newOffer)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var result = _internshipService.AddInternshipOffer(newOffer, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "ApprovedEmployer")]
        [Route("{internshipId}")]
        public IActionResult UpdateInternshipOffer(InternshipOfferToUpdateDto updatedOffer, int internshipId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();



            var internshipToUpdate = _internshipService.GetInternshipOfferByEmployerId(userId, internshipId);

            if (internshipToUpdate.EmployerId != userId)
                return Forbid();

            var result = _internshipService.UpdateInternshipOffer(updatedOffer, internshipId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, ApprovedEmployer")]
        [Route("{internshipId}")]
        public IActionResult DeleteInternshipOffer(int internshipId)
        {


            var result = _internshipService.DeleteInternshipOffer(internshipId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }




        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [Route("{internshipId}/approveoffer")]
        public IActionResult ApproveInternshipOffer(int internshipId, ApproveOffer isApproved)
        {
            var result = _internshipService.ApproveOffer(isApproved.IsApproved, internshipId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

    }
}
