using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Repositories.Interfaces
{
    public interface IWalletRepository
    {
        Task<Wallet> GetWalletByUserIdAsync(int userId);
        Task CreateWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task<List<WalletTransaction>> GetWalletTransactionsAsync(int userId);
    }
}
