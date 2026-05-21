using ElectriStore_BaseProject.DTOs.Login;
using ElectriStore_BaseProject.Repositories.Users;

namespace ElectriStore_BaseProject.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            this._userRepository = userRepository;
        }
        public async Task<LoginResultDTO> LoginAsync(LoginRequestDTO loginRequest)
        {
            var user = await _userRepository.GetUserByEmailAsync(loginRequest.Email);

            if (user == null)
            {
                return new LoginResultDTO
                {
                    Success = false,
                    ErrorMessage = "Tài khoản hoặc mật khẩu không chính xác."
                };
            }

            if (user.IsActive == false)
            {
                return new LoginResultDTO
                {
                    Success = false,
                    ErrorMessage = "Tài khoản hiện tại đang bị khóa"
                };
            }

            if (!VerifyPassword(loginRequest.Password, user.PasswordHash))
            {
                return new LoginResultDTO
                {
                    Success = false,
                    ErrorMessage = "Tài khoản hoặc mật khẩu không chính xác."
                };
            }

            return new LoginResultDTO
            {
                Success = true,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role?.Type ?? "User",
            };
        }

        public bool VerifyPassword(string inputPassword, string? storedPasswordHash)
        {
            if (string.IsNullOrEmpty(storedPasswordHash))
            {
                return false;
            }

            if (inputPassword == storedPasswordHash)
            {
                return true;
            }

            // có thể triển khai kiểm tra mã hóa tại đây
            return false;
        }
    }
}
