using backend.Contexts;
using backend.Entities;
using backend.Models;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/employers")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
    public class ApproveEmployersController : ControllerBase
    {

        private readonly IApproveEmployersRepository _approveEmployersRepository;

        public ApproveEmployersController(IApproveEmployersRepository approveEmployersRepository)
        {
            _approveEmployersRepository = approveEmployersRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<User?>>> GetEmployers()
        {
            var employers = await _approveEmployersRepository.GetEmployers();

            if (employers is null)
                return NotFound();

            return Ok(employers);

        }

        [HttpGet]
        [Route("approvedemployers")]
        public async Task<ActionResult<ICollection<User?>>> GetApprovedEmployers()
        {
            var employers = await _approveEmployersRepository.GetApprovedEmployers();

            if (employers is null)
                return NotFound();

            return Ok(employers);

        }

        [HttpGet]
        [Route("pendingemployers")]
        public async Task<ActionResult<ICollection<User?>>> GetNotApprovedEmployers()
        {
            var employers = await _approveEmployersRepository.GetNotApprovedEmployers();

            if (employers is null)
                return NotFound();

            return Ok(employers);

        }

        [HttpPost]
        [Route("approve/{employerId}")]
        public async Task<ActionResult> ApproveEmployer(string employerId)
        {
            var employer = await _approveEmployersRepository.ApproveEmployer(employerId);

            if (!employer)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });


            return Ok();

        }

        [HttpPost]
        [Route("disapprove/{employerId}")]
        public async Task<ActionResult> DisapproveEmployer(string employerId)
        {
            var employer = await _approveEmployersRepository.DisapproveEmployer(employerId);

            if (!employer)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });


            return Ok();

        }
    }
}
