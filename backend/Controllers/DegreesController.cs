using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Models.Degree;
using backend.Repositories.Interfaces;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{

    [Route("api/degrees")]
    [ApiController]
    public class DegreesController : ControllerBase
    {
        private readonly IDegreeRepository degreeService;
        private readonly IMapper mapper;

        public DegreesController(IDegreeRepository degreeService, IMapper mapper)
        {
            this.degreeService = degreeService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer, ApprovedEmployer")]
        public async Task<ActionResult<ICollection<DegreeDto>>> List()
        {
            var degrees = await this.degreeService.List();


            return Ok(this.mapper.Map<ICollection<DegreeDto>>(degrees));
        }

        [HttpGet("{degreeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer, ApprovedEmployer")]
        public async Task<ActionResult<DegreeDto>> Get(int degreeId)
        {
            var degree = await this.degreeService.Get(degreeId);

            if (degree == null)
                return NotFound("We couldn't find that degree");

            return Ok(this.mapper.Map<DegreeDto>(degree));
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Add(DegreeToCreationDto degreeToCreationDto)
        {
            if (degreeToCreationDto == null)
                return BadRequest();

            var result = await this.degreeService.Add(this.mapper.Map<Degree>(degreeToCreationDto));

            if (result)
                return Ok("Degree created successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpPut("{degreeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Update(DegreeToUpdateDto degreeToUpdateDto, int degreeId)
        {
            if(degreeToUpdateDto.Id != degreeId)
                return BadRequest();

            if (degreeToUpdateDto == null)
                return BadRequest();

            var degreeExist = await this.degreeService.Get(degreeId);

            if (degreeExist == null)
                return NotFound("We couldn't find that degree");

            var result = await this.degreeService.Update(this.mapper.Map<Degree>(degreeToUpdateDto));

            if (result)
                return Ok("Degree updated successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpDelete("{degreeId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> DeleteDegree(int degreeId)
        {
            var degreeExist = await this.degreeService.Get(degreeId);

            if (degreeExist == null)
                return NotFound("We couldn't find that degree");

            var result = await this.degreeService.Delete(degreeId);

            if (result)
                return Ok("Degree deleted successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }
    }
}
