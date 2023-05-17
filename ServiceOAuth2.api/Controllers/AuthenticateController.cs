using Microsoft.AspNetCore.Mvc;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.business.Interfaces;
using ServiceOAuth2.domain.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceOAuth2.api.Controllers
{
    [ApiController]
    [Route("authenticate")]
    public class AuthenticateController : Controller
    {
        private readonly ILogger<AccessTokensController> _logger;

        private readonly IAuthenticateService _authenticateService;

        public AuthenticateController(ILogger<AccessTokensController> logger, IAuthenticateService authenticateService)
        {
            _logger = logger;
            _authenticateService = authenticateService;
        }

        [HttpPost("token-from-user")]
        [SwaggerResponse(200, Type = typeof(TokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAccessTokenFromUser([FromForm] AccessTokenFromUserRequest request)
        {
            try
            {
                return Ok(await _authenticateService.GetAccessTokenFromUser(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPost("token-from-client")]
        [SwaggerResponse(200, Type = typeof(TokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAccessTokenFromClient([FromForm] AccessTokenFromClientRequest request)
        {
            try
            {
                return Ok(await _authenticateService.GetAccessTokenFromClient(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpGet("authorization-code")]
        [SwaggerResponse(200, Type = typeof(TokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAuthorizationCode([FromQuery] AuthorizationCodeRequest request)
        {
            try
            {
                return Ok(await _authenticateService.GetAuthorizationCode(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPost("access-token")]
        [SwaggerResponse(200, Type = typeof(TokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAuthorizationCodeForAccessToken([FromQuery] AuthorizationCodeRequest request)
        {
            try
            {
                return Ok(await _authenticateService.GetAuthorizationCodeForAccessToken(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPost("refresh-token")]
        [SwaggerResponse(200, Type = typeof(TokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> RefreshAccessToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                return Ok(await _authenticateService.RefreshAccessToken(request));
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}
