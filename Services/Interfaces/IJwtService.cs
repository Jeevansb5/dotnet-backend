using OracleJwtApiFull.Models;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
