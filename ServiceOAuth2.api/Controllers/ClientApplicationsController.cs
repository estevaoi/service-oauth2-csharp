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
    [Route("client-applications")]
    public class ClientApplicationsController : Controller
    {
        private readonly ILogger<ClientApplicationsController> _logger;

        private readonly IClientApplicationsService _clientApplicationsService;

        public ClientApplicationsController(ILogger<ClientApplicationsController> logger, IClientApplicationsService clientApplicationsService)
        {
            _logger = logger;
            _clientApplicationsService = clientApplicationsService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<ClientApplicationResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetClientApplications([FromQuery] ClientApplicationsQueryRequest query)
        {
            try
            {
                var response = await _clientApplicationsService.GetClientApplications(query);
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

        [HttpGet("{applicationId}")]
        [SwaggerResponse(200, Type = typeof(ClientApplicationResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetClientApplication([FromQuery] Guid applicationId)
        {
            try
            {
                var response = await _clientApplicationsService.GetClientApplication(new ClientApplicationsQueryRequest { ApplicationId = applicationId });
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
        [SwaggerResponse(200, Type = typeof(ClientApplicationResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PostClientApplication([FromBody] ClientApplicationRequest request)
        {
            try
            {
                var response = await _clientApplicationsService.Insert(request);
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

        [HttpPut("{applicationId}")]
        [SwaggerResponse(200, Type = typeof(ClientApplicationResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PutClientApplication([FromBody] ClientApplicationRequest request, [FromRoute] Guid applicationId)
        {
            try
            {
                var response = await _clientApplicationsService.Update(request, applicationId);
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

        [HttpDelete("{applicationId}")]
        [SwaggerResponse(200, Type = typeof(ClientApplicationResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteClientApplication([FromRoute] Guid applicationId)
        {
            try
            {
                await _clientApplicationsService.Delete(applicationId);
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
