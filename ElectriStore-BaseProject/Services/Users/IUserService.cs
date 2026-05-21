using ElectriStore_BaseProject.DTOs.Login;
using ElectriStore_BaseProject.DTOs.Registers;

namespace ElectriStore_BaseProject.Services.Users
{
    public interface IUserService
    {
        Task<LoginResultDTO> LoginAsync(LoginRequestDTO loginRequest);

        Task<RegisterResultDTO> RegisterAsync(RegisterRequestDTO registerRequest);

    }
}
