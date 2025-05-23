using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services.Interfaces
{
    public interface IWalletService
    {
        WalletDTO GetBalance(int userId);
        Task CreateWallet(int userId);
        decimal Credit(int userId, decimal amount);
        decimal Debit(int userId, decimal amount);
        List<WalletTransaction> GetTransactions(int userId);
    }
}
