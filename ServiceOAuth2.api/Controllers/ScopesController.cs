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
    [Route("scopes")]
    public class ScopesController : Controller
    {
        private readonly ILogger<ScopesController> _logger;

        private readonly IScopesService _scopesService;

        public ScopesController(ILogger<ScopesController> logger, IScopesService scopesService)
        {
            _logger = logger;
            _scopesService = scopesService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<ScopeResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetScopes([FromQuery] ScopesQueryRequest query)
        {
            try
            {
                var response = await _scopesService.GetScopes(query);
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

        [HttpGet("{scopeId}")]
        [SwaggerResponse(200, Type = typeof(ScopeResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetScope([FromQuery] Guid scopeId)
        {
            try
            {
                var response = await _scopesService.GetScope(new ScopesQueryRequest { ScopeId = scopeId });
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
        [SwaggerResponse(200, Type = typeof(ScopeResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PostScope([FromBody] ScopeRequest request)
        {
            try
            {
                var response = await _scopesService.Insert(request);
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

        [HttpPut("{scopeId}")]
        [SwaggerResponse(200, Type = typeof(ScopeResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PutScope([FromBody] ScopeRequest request, [FromRoute] Guid scopeId)
        {
            try
            {
                var response = await _scopesService.Update(request, scopeId);
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

        [HttpDelete("{scopeId}")]
        [SwaggerResponse(200, Type = typeof(ScopeResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteScope([FromRoute] Guid scopeId)
        {
            try
            {
                await _scopesService.Delete(scopeId);
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
