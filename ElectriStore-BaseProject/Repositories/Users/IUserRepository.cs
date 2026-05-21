using ElectriStore_BaseProject.Models;
using ElectriStore_BaseProject.DTOs.Registers;

namespace ElectriStore_BaseProject.Repositories.Users
{
    public interface IUserRepository
    {
        // this func used to Login
        Task<User?> GetUserByEmailAsync(string email);

        Task<User?> GetUserByPhoneNumberAsync(string PhoneNumber);

        Task<bool> SaveUser(User newUser); 
    }
}
