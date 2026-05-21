using ElectriStore_BaseProject.Models;

namespace ElectriStore_BaseProject.Repositories.Users
{
    public interface IUserRepository
    {
        // this func used to Login
        Task<User?> GetUserByEmailAsync(string email);
    }
}
