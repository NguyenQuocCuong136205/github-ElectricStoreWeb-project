using ElectriStore_BaseProject.DTOs.Login;

namespace ElectriStore_BaseProject.Services.Users
{
    public interface IUserService
    {
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO loginRequest);
    }
}
