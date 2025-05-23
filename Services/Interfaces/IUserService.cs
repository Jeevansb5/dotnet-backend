using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<string> LoginAsync(LoginDto dto);
        Task<User> GetUserByIdAsync(int id);
        Task<string> UpdateUserAsync(int id, UpdateUserDto dto);
    }
}
