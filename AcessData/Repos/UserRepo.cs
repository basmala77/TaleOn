using AccessData.Repos.IRepo;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace AccessData.Repos
{
    public class UserRepo : Repository<ApplicationUser>, IUserRepos
    {
        private readonly ApplicationDbContext db;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration configuration;
        private readonly IEmailSend emailSend;
        private readonly string securityKey;
        private readonly IOtpService otpService;

        public UserRepo(
            ApplicationDbContext db,
            IConfiguration configuration,
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            RoleManager<IdentityRole> roleManager,
            IEmailSend emailSend,
            IOtpService otp) : base(db)
        {
            this.db = db;
            this.configuration = configuration;
            this.userManager = userManager;
            this.mapper = mapper;
            this.roleManager = roleManager;
            this.emailSend = emailSend;
            otpService = otp;

            securityKey = configuration.GetValue<string>("ApiSettings:Secret")
                ?? throw new InvalidOperationException("ApiSettings:Secret is not configured.");
        }

 
        public async Task<int> GetChildrenCountAsync(string parentId)
        {
            return await db.childUsers.CountAsync(c => c.ParentId == parentId);
        }

        public async Task<ApplicationUser> GetUserByID(int userID)
        {
            var user = await db.applicationUsers.FindAsync(userID);
            return user ?? throw new InvalidOperationException("User not found.");
        }

        public async Task<bool> IsUniqueUserName(string username)
        {
            var matchUser = await userManager.FindByNameAsync(username);
            return matchUser == null; 
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDTO.Email);
            if (user == null || !await userManager.CheckPasswordAsync(user, loginRequestDTO.Password))
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null,
                };
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new(ClaimTypes.Name, user.UserName ?? user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: creds);

            return new LoginResponseDTO()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                User = mapper.Map<UserDTO>(user),
            };
        }

        public async Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO)
        {
            var userDto = new UserDTO();

            if (registerRequestDTO.Password != registerRequestDTO.ConfirmPassword)
            {
                userDto.ErrorMessages = new List<string> { "Password and Confirm Password do not match." };
                return userDto;
            }

            var user = new ApplicationUser
            {
                Name = registerRequestDTO.Name,
                Email = registerRequestDTO.Email,
                UserName = registerRequestDTO.Email,
                NormalizedEmail = registerRequestDTO.Email.ToUpper(),
                NormalizedUserName = registerRequestDTO.Email.ToUpper()
            };

            try
            {
                var result = await userManager.CreateAsync(user, registerRequestDTO.Password);
                if (!result.Succeeded)
                {
                    userDto.ErrorMessages = result.Errors.Select(e => e.Description).ToList();
                    return userDto;
                }

                var otp = await otpService.GenerateOtpAsync(user.Id);
                emailSend.SendEmail(user.Email, "Confirm your email", $"Welcome {user.Name}! \n Please confirm your email with this code: {otp}");

                userDto = mapper.Map<UserDTO>(user);
                userDto.Success = true;
            }
            catch (Exception ex)
            {
                userDto.ErrorMessages = new List<string> { "Internal server error occurred." };
            }

            return userDto;
        }

        public async Task<bool> UpdateAsync(ApplicationUser user)
        {
            db.applicationUsers.Update(user);
            var rows = await db.SaveChangesAsync();
            return rows > 0;
        }
    }
}
