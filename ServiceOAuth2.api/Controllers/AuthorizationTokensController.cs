using Microsoft.AspNetCore.Mvc;
using ServiceOAuth2.business.Data.QueryRequest;
using ServiceOAuth2.business.Data.Request;
using ServiceOAuth2.business.Data.Response;
using ServiceOAuth2.business.Services;
using ServiceOAuth2.domain.Response;
using Swashbuckle.AspNetCore.Annotations;

namespace ServiceOAuth2.api.Controllers
{
    [ApiController]
    [Route("authorization-tokens")]
    public class AuthorizationTokensController : Controller
    {
        private readonly ILogger<AuthorizationTokensController> _logger;

        private readonly IAuthorizationTokensService _authorizationTokensService;

        public AuthorizationTokensController(ILogger<AuthorizationTokensController> logger, IAuthorizationTokensService authorizationTokensService)
        {
            _logger = logger;
            _authorizationTokensService = authorizationTokensService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<AuthorizationTokenResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAuthorizationTokens([FromQuery] AuthorizationTokensQueryRequest query)
        {
            try
            {
                var response = await _authorizationTokensService.GetAuthorizationTokens(query);
                return Ok(new { response.Items, response.Pagination });
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpGet("{authorizationTokenId}")]
        [SwaggerResponse(200, Type = typeof(AuthorizationTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAuthorizationToken([FromQuery] Guid authorizationTokenId)
        {
            try
            {
                var response = await _authorizationTokensService.GetAuthorizationToken(new AuthorizationTokensQueryRequest { AuthorizationTokenId = authorizationTokenId });
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPost]
        [SwaggerResponse(200, Type = typeof(AuthorizationTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PostAuthorizationToken([FromBody] AuthorizationTokenRequest request)
        {
            try
            {
                var response = await _authorizationTokensService.Insert(request);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpPut("{authorizationTokenId}")]
        [SwaggerResponse(200, Type = typeof(AuthorizationTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PutAuthorizationToken([FromBody] AuthorizationTokenRequest request, [FromRoute] Guid authorizationTokenId)
        {
            try
            {
                var response = await _authorizationTokensService.Update(request, authorizationTokenId);
                return Ok(response);
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }

        [HttpDelete("{authorizationTokenId}")]
        [SwaggerResponse(200, Type = typeof(AuthorizationTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteAuthorizationToken([FromRoute] Guid authorizationTokenId)
        {
            try
            {
                await _authorizationTokensService.Delete(authorizationTokenId);
                return NoContent();
            }
            catch (UnauthorizedAccessException)
            {
                return Forbid();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
        }
    }
}
