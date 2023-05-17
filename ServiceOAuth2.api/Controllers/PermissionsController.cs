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
    [Route("permissions")]
    public class PermissionsController : Controller
    {
        private readonly ILogger<PermissionsController> _logger;

        private readonly IPermissionsService _permissionsService;

        public PermissionsController(ILogger<PermissionsController> logger, IPermissionsService permissionsService)
        {
            _logger = logger;
            _permissionsService = permissionsService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<PermissionResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetPermissions([FromQuery] PermissionsQueryRequest query)
        {
            try
            {
                var response = await _permissionsService.GetPermissions(query);
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

        [HttpGet("{permissionId}")]
        [SwaggerResponse(200, Type = typeof(PermissionResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        private async Task<IActionResult> GetPermission([FromQuery] Guid permissionId)
        {
            try
            {
                var response = await _permissionsService.GetPermission(new PermissionsQueryRequest { PermissionId = permissionId });
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
        [SwaggerResponse(200, Type = typeof(PermissionResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        private async Task<IActionResult> PostPermission([FromBody] PermissionRequest request)
        {
            try
            {
                var response = await _permissionsService.Insert(request);
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

        [HttpPut("{permissionId}")]
        [SwaggerResponse(200, Type = typeof(PermissionResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        private async Task<IActionResult> PutPermission([FromBody] PermissionRequest request, [FromRoute] Guid permissionId)
        {
            try
            {
                var response = await _permissionsService.Update(request, permissionId);
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

        [HttpDelete("{permissionId}")]
        [SwaggerResponse(200, Type = typeof(PermissionResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeletePermission([FromRoute] Guid permissionId)
        {
            try
            {
                await _permissionsService.Delete(permissionId);
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
