using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
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
        public ParentController(IParentService parentService, ILogger<ParentController> logger)
        {
            _parentService = parentService;
            _logger = logger;

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

        [HttpPut("profile")]
        public async Task<IActionResult> UpdateProfile([FromForm] ParentProfileUpdateDto dto)
        {
            dto.Id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);



            try
            {
                var updatedProfile = await _parentService.EditParentProfileAsync(dto);

                return Ok(new
                {
                    success = true,
                    message = "Profile updated successfully",
                    data = updatedProfile
                });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new
                {
                    success = false,
                    message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "An unexpected error occurred",
                    details = ex.Message
                });
            }
        }


    }
}

