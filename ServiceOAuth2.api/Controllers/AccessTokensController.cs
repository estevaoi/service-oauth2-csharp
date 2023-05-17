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
    [Route("access-tokens")]
    public class AccessTokensController : Controller
    {
        private readonly ILogger<AccessTokensController> _logger;

        private readonly IAccessTokensService _accessTokensService;

        public AccessTokensController(ILogger<AccessTokensController> logger, IAccessTokensService accessTokensService)
        {
            _logger = logger;
            _accessTokensService = accessTokensService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<AccessTokenResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAccessTokens([FromQuery] AccessTokensQueryRequest query)
        {
            try
            {
                var response = await _accessTokensService.GetAccessTokens(query);
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

        [HttpGet("{accessTokenId}")]
        [SwaggerResponse(200, Type = typeof(AccessTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetAccessToken([FromQuery] Guid accessTokenId)
        {
            try
            {
                var response = await _accessTokensService.GetAccessToken(new AccessTokensQueryRequest { AccessTokenId = accessTokenId });
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
        [SwaggerResponse(200, Type = typeof(AccessTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        private async Task<IActionResult> PostAccessToken([FromBody] AccessTokenRequest request)
        {
            try
            {
                var response = await _accessTokensService.Insert(request);
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

        [HttpPut("{accessTokenId}")]
        [SwaggerResponse(200, Type = typeof(AccessTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        private async Task<IActionResult> PutAccessToken([FromBody] AccessTokenRequest request, [FromRoute] Guid accessTokenId)
        {
            try
            {
                var response = await _accessTokensService.Update(request, accessTokenId);
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

        [HttpDelete("{accessTokenId}")]
        [SwaggerResponse(200, Type = typeof(AccessTokenResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteAccessToken([FromRoute] Guid accessTokenId)
        {
            try
            {
                await _accessTokensService.Delete(accessTokenId);
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
