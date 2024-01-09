using backend.Models;
using backend.Models.Application;
using backend.Services.Implementations;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationInternshipService _applicationService;
        private readonly IApplicationHiredService _applicationHiredService;
        private readonly IHiredEmployeeOfferService _employeeOfferService;
        private readonly IInternshipService _internshipService;
        private readonly MailService _mailService;
        public ApplicationController(IApplicationInternshipService applicationService,
            IApplicationHiredService applicationHiredService,
            IHiredEmployeeOfferService employeeOfferService,
            IInternshipService internshipService,
            MailService mailService
            )
        {
            _applicationService = applicationService;
            _applicationHiredService = applicationHiredService;
            _employeeOfferService = employeeOfferService;
            _internshipService = internshipService;
            _mailService = mailService;
        }

        [HttpGet]
        [Route("internships/{internshipId}")]
        public ActionResult<ICollection<ApplicationInternshipDto>?> GetApplicationsByInternship(int internshipId)
        {


            var applications = _applicationService.GetApplicationsByInternship(internshipId);

            if (applications == null)
                return NotFound("No se encontraron postulaciones para esa oferta");
            return Ok(applications);
        }

        [HttpGet]
        [Route("hired/{hiredId}")]
        public ActionResult<ICollection<ApplicationHiredDto>?> GetApplicationsByHired(int hiredId)
        {

            var applications = _applicationHiredService.GetApplicationsByHired(hiredId);

            if (applications == null)
                return NotFound("No se encontraron postulaciones para esa oferta");

            return Ok(applications);
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpGet]
        [Route("allbystudent")]
        public ActionResult<ICollection<AllApplications>?> GetApplicationsByStudent()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var happlications = _applicationHiredService.GetApplicationsByStudent(userId);
            var iapplications = _applicationService.GetApplicationsByStudent(userId);

            var applys = new AllApplications()
            {
                HiredApplications = happlications,
                InternshipApplications = iapplications
            };

            if (applys == null)
                return NotFound("No se encontraron postulaciones para esa oferta");

            return Ok(applys);
        }



        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpPost]
        [Route("internship")]
        public ActionResult<ICollection<ApplicationInternshipDto>?> ApplyInternship(ApplicationInternshipToCreationDto application)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            var offer = _internshipService.GetInternshipOffer(application.InternshipOfferId);

            if (offer is null)
                return NotFound("No se encontro la pasantia a la que te quieres postular");



            var result = _applicationService.Apply(application, userId);


            if (result is false)
                return NotFound("No se pudo postular a la pasantia");




            var mailResult = _mailService.enviaMail(offer.EmailReceiver,
                                "User se acaba de postular a la oferta de Oferta",
                                "Nuevo postulante", userId);

            if (mailResult)
            {
                Console.Write("se envio el mail");

            }
            else
            {
                Console.Write("no se envio el mail");

            }

            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpPost]
        [Route("hired")]
        public ActionResult<ICollection<ApplicationHiredDto>?> ApplyHired(ApplicationHiredToCreationDto application)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var offer = _employeeOfferService.GetHiredEmployeeOffer(application.HiredEmployeeOfferId);

            if (offer is null)
                return NotFound("No se encontro la oferta a la que te quieres postular");

            var result = _applicationHiredService.Apply(application, userId);


            if (result is false)
                return NotFound("No se pudo postular a la pasantia");

            var mailResult = _mailService.enviaMail(offer.EmailReceiver,
                               $"Nuevo aplicante con email: {userEmail} para la oferta de: {offer.Title}",
                               "Nuevo postulante", userId);

            if (mailResult)
            {
                Console.Write("se envio el mail");

            }
            else
            {
                Console.Write("no se envio el mail");

            }


            return NoContent();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpDelete]
        [Route("hired/{offerId}")]
        public ActionResult<ICollection<ApplicationHiredDto>?> CancelApplyHired(int offerId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var result = _applicationHiredService.CancelApply(offerId);

            if (result is true)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [HttpDelete]
        [Route("internship/{offerId}")]
        public ActionResult<ICollection<ApplicationHiredDto>?> CancelApplyInternship(int offerId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


            var result = _applicationService.CancelApply(offerId);

            if (result is true)
                return NoContent();

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

        }


        [HttpGet]
        [Route("postulant/{studentId}")]
        public ActionResult<PostulantDataDto> GetPostulantData(string studentId)
        {


            var result = _applicationHiredService.GetPostulantData(studentId);

            if (result is null)
                return NotFound();

            return Ok(result);

        }
    }
}
