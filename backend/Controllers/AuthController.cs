using backend.Entities;
using backend.Models.Auth;
using backend.Services.Implementations;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _config;
        private readonly IJwtGeneratorService _jwtGeneratorService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RefreshTokenService _refreshTokenService;


        public AuthController(UserManager<User> userManager, IConfiguration config, IJwtGeneratorService jwtGeneratorService, RoleManager<IdentityRole> roleManager, RefreshTokenService refreshTokenService)
        {
            _userManager = userManager;
            _config = config;
            _jwtGeneratorService = jwtGeneratorService;
            _roleManager = roleManager;
            _refreshTokenService = refreshTokenService;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<TokenModel>> AuthUser(AuthRequestDto request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return Unauthorized("Usuario y/o contraseña incorrecto/a");
            }

            var roles = await _userManager.GetRolesAsync(user);

            if (roles is null)
                return Unauthorized("Oops, no tienes roles!");

            var jwt = _jwtGeneratorService.GenerateAuthToken(user, roles);




            return Ok(jwt);
        }



        [HttpPost]
        [Route("refresh")]
        public async Task<ActionResult<TokenModel>> RefreshToken(TokenModel request)
        {

            var tokens = await _refreshTokenService.Handle(request);

            if (tokens is null)
                return Unauthorized();

            return Ok(new TokenModel()
            {
                AccessToken = tokens.AccessToken,
                RefreshToken = tokens.RefreshToken
            });
        }

        [HttpPost]
        [Route("RegisterStudent")]
        public async Task<IActionResult> Register(RegisterStudentDto model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return Conflict("Ya hay un usuario con ese email registrado.");

            Student user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (!await _roleManager.RoleExistsAsync("Student"))
                await _roleManager.CreateAsync(new IdentityRole("Student"));

            await _userManager.AddToRoleAsync(user, "Student");


            var userInDb = await _userManager.FindByEmailAsync(model.Email);

            var roles = await _userManager.GetRolesAsync(userInDb);

            var jwt = _jwtGeneratorService.GenerateAuthToken(userInDb, roles);

            return Ok(jwt);
        }

        [HttpPost]
        [Route("RegisterBusiness")]
        public async Task<IActionResult> Register(RegisterEmployerDto model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);

            if (userExists != null)
                return Conflict("Ya hay un usuario registrado con ese email.");

            Employer user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError);

            if (!await _roleManager.RoleExistsAsync("Employer"))
                await _roleManager.CreateAsync(new IdentityRole("Employer"));

            await _userManager.AddToRoleAsync(user, "Employer");


            var userInDb = await _userManager.FindByEmailAsync(model.Email);

            var roles = await _userManager.GetRolesAsync(userInDb);

            var jwt = _jwtGeneratorService.GenerateAuthToken(userInDb, roles);

            return Ok(jwt);
        }
    }
}
