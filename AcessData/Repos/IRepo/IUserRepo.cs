using Models.DTOs;
using Models.Entities;


namespace AccessData.Repos.IRepo
{
    public interface IUserRepos : IRepository<ApplicationUser>
    {
        Task<bool> IsUniqueUserName(string username);
        Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO);
        Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO);
        Task<ApplicationUser> GetUserByID(int userID);
        Task<bool> UpdateAsync(ApplicationUser user);
        Task<int> GetChildrenCountAsync(string parentId);
    }
}
