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
    [Route("users")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;

        private readonly IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpGet]
        [SwaggerResponse(200, Type = typeof(ListResponse<UserResponse>))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUsers([FromQuery] UsersQueryRequest query)
        {
            try
            {
                var response = await _usersService.GetUsers(query);
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

        [HttpGet("{userId}")]
        [SwaggerResponse(200, Type = typeof(UserResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> GetUser([FromQuery] Guid userId)
        {
            try
            {
                var response = await _usersService.GetUser(new UsersQueryRequest { UserId = userId });
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
        [SwaggerResponse(200, Type = typeof(UserResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PostUser([FromBody] UserRequest request)
        {
            try
            {
                var response = await _usersService.Insert(request);
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

        [HttpPut("{userId}")]
        [SwaggerResponse(200, Type = typeof(UserResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> PutUser([FromBody] UserRequest request, [FromRoute] Guid userId)
        {
            try
            {
                var response = await _usersService.Update(request, userId);
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

        [HttpDelete("{userId}")]
        [SwaggerResponse(200, Type = typeof(UserResponse))]
        [SwaggerResponse(400, Type = typeof(ErrorResponse))]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid userId)
        {
            try
            {
                await _usersService.Delete(userId);
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
