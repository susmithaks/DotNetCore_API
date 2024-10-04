using DotNetCore_API.Models.DTO;
using DotNetCore_API.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITokenRepository _tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager , ITokenRepository tokenRepository)
        {
            _userManager = userManager;
            _tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequestDto registerRequestDto)
        {

            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            
           var identityResult = await _userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if(identityResult.Succeeded)
            {
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
                {
                    await _userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if(identityResult.Succeeded)
                    {
                        return Ok("User was Registerd");
                    }
                }

               
            }
            return BadRequest("Something went Wrong");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {

           var user = await _userManager.FindByEmailAsync(loginRequestDto.UserName);
            if(user != null)
            {
                var checkPasswordResult = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if(checkPasswordResult)
                {
                    //get roles
                    var roles = await _userManager.GetRolesAsync(user);
                    if(roles != null)
                    {
                        //create token
                        var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());
                        var reposnse = new LoginResponceDto
                        {
                            JwtToken = jwtToken
                        };
                    return Ok(reposnse);
                    }
                    
                }
            }
            return BadRequest("UserName or Password incorrect");

        }

    }
}
