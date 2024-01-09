using backend.Models;
using backend.Models.Skill;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/skills")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService _skillService;
        public SkillsController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        public ActionResult<ICollection<SkillDto>> GetMySkills()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var skills = _skillService.GetSkills(userId);

            if (skills == null)
                return NotFound();

            return Ok(skills);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public ActionResult<ICollection<SkillDto>> GetMySkill(int skillId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var skills = _skillService.GetSkill(skillId, userId);

            if (skills == null)
                return NotFound();

            return Ok(skills);
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        public IActionResult AddSkill(SkillToCreationDto newSkill)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var result = _skillService.AddSkill(newSkill, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public IActionResult UpdateInternshipOffer(SkillToUpdateDto updatedSkill, int skillId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();



            var internshipToUpdate = _skillService.GetSkill(skillId, userId);

            if (internshipToUpdate.StudentId != userId)
                return Forbid();

            var result = _skillService.UpdateSkill(updatedSkill, skillId, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }


        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public IActionResult DeleteInternshipOffer(int skillId)
        {


            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();



            var skillToDelete = _skillService.GetSkill(skillId, userId);

            if (skillToDelete.StudentId != userId)
                return Forbid();

            var result = _skillService.DeleteSkill(skillId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }
    }
}
