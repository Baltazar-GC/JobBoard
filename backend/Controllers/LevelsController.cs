using AutoMapper;
using backend.Entities;
using backend.Models;
using backend.Models.TechnologyLevel;
using backend.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/levels")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ITechnologyLevelRepository levelsService;
        private readonly IMapper mapper;

        public LevelsController(ITechnologyLevelRepository levelsService, IMapper mapper)
        {
            this.levelsService = levelsService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        public async Task<ActionResult<ICollection<TechnologyLevelDto>>> List()
        {
            var levels = await this.levelsService.List();

            return Ok(levels);
        }

        [HttpGet("{levelId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Student, Employer")]
        public async Task<ActionResult<TechnologyLevelDto>> Get(int levelId)
        {
            var level = await this.levelsService.Get(levelId);

            if (level == null)
                return NotFound("We couldn't find that level");

            return Ok(level);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Add(TechnologyLevelToCreationDto levelToCreationDto)
        {
            if (levelToCreationDto == null)
                return BadRequest();

            var result = await this.levelsService.Add(this.mapper.Map<TechnologyLevel>(levelToCreationDto));

            if (result)
                return Ok("Level created successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpPut("{levelId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> Update(TechnologyLevelToUpdateDto levelToUpdateDto, int levelId)
        {
            if (levelToUpdateDto.Id != levelId)
                return BadRequest();

            var levelExist = await this.levelsService.Get(levelId);

            if (levelExist == null)
                return NotFound("We couldn't find that level");

            var result = await this.levelsService.Update(this.mapper.Map<TechnologyLevel>(levelToUpdateDto));

            if (result)
                return Ok("Level updated successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }

        [HttpDelete("{levelId}")]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        public async Task<ActionResult> DeleteLevel(int levelId)
        {
            var levelExist = await this.levelsService.Get(levelId);

            if (levelExist == null)
                return NotFound("We couldn't find that level");

            var result = await this.levelsService.Delete(levelId);

            if (result)
                return Ok("Level deleted successfully");

            return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Something went wrong, try again" });
        }
    }
}
