using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tecnofactory.Alimentos.BL.Interface;
using Tecnofactory.Alimentos.DTO;

namespace Tecnofactory.Alimentos.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticateController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticateController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            string response = await _authenticationService.Login(request);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            string response = await _authenticationService.Register(request);
            return Ok(response);
        }
    }
}