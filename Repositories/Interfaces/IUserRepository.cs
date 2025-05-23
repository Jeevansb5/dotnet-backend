using OracleJwtApiFull.Models;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> EmailExistsAsync(string email);
        Task AddUserAsync(User user);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task UpdateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
