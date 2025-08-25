using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccessData.Repos.IRepo;

namespace TaleOn.Services.ControllerService.IControllerService
{
    public interface IAuthService
    {

        Task<LoginResponseDTO> LoginAsync(LoginRequestDTO loginRequestDto);
        Task<UserDTO> RegisterAsync(RegisterRequestDTO registerRequestDto);
    }
}
