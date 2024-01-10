using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/technologies")]
    [ApiController]
    public class TechnologyController : ControllerBase
    {
        private readonly ITechnologyRepository technologyService;
        private readonly IMapper mapper;

        public TechnologyController(ITechnologyRepository technologyService, IMapper mapper)
        {
            this.technologyService = technologyService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        public async Task<ActionResult<ICollection<TechnologyDto>>> List()
        {
            var technologies = await this.technologyService.List();

            return Ok(this.mapper.Map<ICollection<TechnologyDto>>(technologies));
        }

        [HttpGet("{technologyId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        public async Task<ActionResult<TechnologyDto>> Get(int technologyId)
        {
            var technology = await this.technologyService.Get(technologyId);

            if (technology == null)
                return NotFound("We couldn't find that technology");

            return Ok(technology);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Add(TechnologyToCreationDto newTechnology)
        {
            var result = await this.technologyService.Add(this.mapper.Map<Technology>(newTechnology));

            if (result)
                return Ok("Technology created successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpPut("{technologyId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Update(TechnologyToUpdateDto updatedTechnology, int technologyId)
        {
            if(updatedTechnology.Id != technologyId)
                return BadRequest();

            var technology = await this.technologyService.Get(technologyId);

            if (technology == null)
                return NotFound("We couldn't find that technology");

            var result = await this.technologyService.Update(this.mapper.Map<Technology>(updatedTechnology));

            if (result)
                return Ok("Technology updated successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpDelete("{technologyId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Delete(int technologyId)
        {
            var technology = await this.technologyService.Get(technologyId);

            if (technology == null)
                return NotFound("We couldn't find that technology");

            var result = await this.technologyService.Delete(technologyId);

            if (result)
                return Ok("Technology deleted successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }
    }
}
