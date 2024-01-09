using backend.Models;
using backend.Models.OtherSkills;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/otherskills")]
    [ApiController]
    public class OtherSkillsController : ControllerBase
    {

        private readonly IOtherSkillsService _skillService;
        public OtherSkillsController(IOtherSkillsService skillService)
        {
            _skillService = skillService;
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        public ActionResult<ICollection<OtherSkillsDto>> GetMyOtherSkills()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var skills = _skillService.GetOtherSkills(userId);

            if (skills == null)
                return NotFound();

            return Ok(skills);
        }

        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public ActionResult<ICollection<OtherSkillsDto>> GetMyOtherSkill(int skillId)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var skills = _skillService.GetOtherSkill(skillId, userId);

            if (skills == null)
                return NotFound();

            return Ok(skills);
        }
        //[Authorize(AuthenticationSchemes = "Bearer", Roles = "Employer")]

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        public IActionResult AddSkill(OtherSkillsToCreationDto newSkill)
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();

            var result = _skillService.AddOtherSkill(newSkill, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public IActionResult UpdateInternshipOffer(OtherSkillsToUpdateDto updatedSkill, int skillId)
        {

            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();



            var skilltoupdate = _skillService.GetOtherSkill(skillId, userId);

            if (skilltoupdate.StudentId != userId)
                return Forbid();

            var result = _skillService.UpdateOtherSkill(updatedSkill, skillId, userId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }


        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Student")]
        [Route("{skillId}")]
        public IActionResult DeleteOtherSkill(int skillId)
        {


            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
                return Unauthorized();



            var skillToDelete = _skillService.GetOtherSkill(skillId, userId);

            if (skillToDelete.StudentId != userId)
                return Forbid();

            var result = _skillService.DeleteOtherSkill(skillId);

            if (result is false)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Algo salio mal, vuelve a intentarlo" });

            return NoContent();
        }
    }
}
