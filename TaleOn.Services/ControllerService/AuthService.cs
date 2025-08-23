using AccessData.Repos.IRepo;
using Models.DTOs;
using System.ComponentModel.DataAnnotations;
using TaleOn.Services.ControllerService.IControllerService;

namespace TaleOn.Services.ControllerService
{
    public class AuthService : IAuthService
    {
        private readonly  IUserRepos _userRepository;

        public AuthService(IUserRepos userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDto)
        {
            return await _userRepository.Login(loginRequestDto);
        }

        public async Task<UserDTO> RegisterAsync(RegisterRequestDTO registerRequestDto)
        {
            var emailExist = await _userRepository.GetAsync(user => user.Email == registerRequestDto.Email);
            if (emailExist != null)
            {
                throw new ValidationException("Email Already exists");
            }

            return await _userRepository.Register(registerRequestDto);
        }
    }
}
