using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaleOn.Services.ControllerService.IControllerService;
namespace TaleOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ParentController : ControllerBase
    {
        private readonly ILogger<ParentController> _logger;
        private readonly IParentService _parentService;
        public ParentController(IParentService parentService) 
        {
            _parentService = parentService;

        }



        [HttpGet("Profile")]
        public async Task<IActionResult> GetParentProfileAsync()
        {
            try
            {
                // هجيب الـ Id من التوكن مباشرة
                var parentId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (string.IsNullOrEmpty(parentId))
                {
                    return Unauthorized(new { message = "Invalid token or user not authenticated." });
                }

                var parentProfile = await _parentService.GetParentProfileAsync(parentId);
                return Ok(parentProfile);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "An error occurred while processing your request." });
            }
        }


    }
}
