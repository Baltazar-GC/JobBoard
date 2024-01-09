using backend.Models;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class AllOffers : ControllerBase
    {
        private readonly IInternshipService _internshipService;
        private readonly IHiredEmployeeOfferService _hiredEmployeeOfferService;

        public AllOffers(IInternshipService internshipService, IHiredEmployeeOfferService hiredEmployeeOfferService)
        {
            _internshipService = internshipService;
            _hiredEmployeeOfferService = hiredEmployeeOfferService;
        }

        [HttpGet]
        public ActionResult<dynamic> GetAllPublicOffers()
        {

            var offers = new AllApprovedOffers();

            offers.HiredEmployeeOffers = _hiredEmployeeOfferService.GetAll();
            offers.Internships = _internshipService.GetApprovedIntenships();


            if ((offers.Internships is null && offers.HiredEmployeeOffers is null)
                || (offers.HiredEmployeeOffers.Count() <= 0 && offers.HiredEmployeeOffers.Count() <= 0))
                return NotFound("No se encontraron offertas publicadas");

            return offers;
        }
    }
}
