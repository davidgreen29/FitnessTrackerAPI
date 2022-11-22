using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using trackerApi.Contracts;
using trackerApi.Models.Users;

namespace trackerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthManager _authManager; 
        private readonly ILogger<AuthenticationController> _logger;
        public AuthenticationController(IAuthManager authManger, ILogger<AuthenticationController> logger)
        {
            this._authManager = authManger;
            this._logger = logger;
        }

        //POST: api/Account/register
        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"Registration attempt for ${ apiUserDto.Email}");
            var errors = await _authManager.Register(apiUserDto);
            if (errors.Any())
            {
                foreach(var error in errors)
                {
                    ModelState.AddModelError(error.Code,error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();
        
        }


        //POST: api/Account/register
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            _logger.LogInformation($"Login Attempt for {loginDto.Email}");
            var authResponse = await _authManager.Login(loginDto);
            if(authResponse == null)
            {
              return Unauthorized();    
            }

            return Ok(authResponse);

        }

        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        //POST: api/Account/refreshtoken
        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManager.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }







    }
}
