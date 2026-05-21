using ElectriStore_BaseProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ElectriStore_BaseProject.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ElectronicStoreContext _context;

        public UserRepository(ElectronicStoreContext context)
        {
            _context = context;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByPhoneNumberAsync(string PhoneNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Phone == PhoneNumber);
        }

        public async Task<bool> SaveUser(User newUser)
        {
            try
            {
                await _context.Users.AddAsync(newUser);

                int rowsAffected = await _context.SaveChangesAsync();

                return rowsAffected > 0;
            }
            catch
            {
                return false;
            }
        }
    }
}
