using AccessData.Repos.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs;
using TaleOn.Services.ControllerService.IControllerService;

namespace TaleOn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserController(IAuthService authService,IOtpService otpService,UserManager<Models.Entities.ApplicationUser> _userManager) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDto)
        {
            var result = await authService.LoginAsync(loginRequestDto);
            if (result.User == null)
                return BadRequest("Email or password is wrong");
            return Ok(result);  
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDto)
        {
            try
            {
                var result = await authService.RegisterAsync(registerRequestDto);
                 if (result.ErrorMessages != null && result.ErrorMessages.Any())
                 {
                    return BadRequest(new { Message = "Registration failed.", Errors = result.ErrorMessages });
                 }

                return Ok(new { Message = "User registered successfully! Check your email for the OTP.", User = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ex.Message, ex.StackTrace });
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDTO dto)
        {
            var isValid = await otpService.VerifyOtpAsync(dto.UserId, dto.OtpCode);
            if (!isValid) return BadRequest(new { Message = "Invalid or expired OTP." });

            var user = await _userManager.FindByIdAsync(dto.UserId);
            if (user == null)
                return NotFound(new { Message = "User not found." });

            user.EmailConfirmed = true;
            await _userManager.UpdateAsync(user);

            return Ok(new { Message = "Email confirmed successfully." });
        }

    }
}
