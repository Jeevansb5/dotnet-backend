using Microsoft.EntityFrameworkCore;
using OracleJwtApiFull.Data;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services
{
    public class WalletService : IWalletService
    {
        private readonly ApplicationDbContext _context;

        public WalletService(ApplicationDbContext context)
        {
            _context = context;
        }

        public WalletDTO GetBalance(int userId)
        {
            var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
            if (wallet == null)
                throw new InvalidOperationException("Wallet not found");

            return new WalletDTO
            {
                WalletId = wallet.UserId,  // ✅ Use `Id` instead
                Balance = wallet.Balance
            };

        }

        public async Task CreateWallet(int userId)
        {
            if (!await _context.Wallets.AnyAsync(w => w.UserId == userId))
            {
                var wallet = new Wallet
                {
                    UserId = userId,
                    Balance = 0
                };

                _context.Wallets.Add(wallet);
                await _context.SaveChangesAsync();
            }
        }

        public decimal Credit(int userId, decimal amount)
        {
            var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
            if (wallet == null) throw new InvalidOperationException("Wallet not found");

            wallet.Balance += amount;
            _context.SaveChanges();
            return wallet.Balance;
        }

        public decimal Debit(int userId, decimal amount)
        {
            var wallet = _context.Wallets.FirstOrDefault(w => w.UserId == userId);
            if (wallet == null) throw new InvalidOperationException("Wallet not found");

            if (wallet.Balance < amount)
                throw new InvalidOperationException("Insufficient balance");

            wallet.Balance -= amount;
            _context.SaveChanges();
            return wallet.Balance;
        }

        public List<WalletTransaction> GetTransactions(int userId)
        {
            return _context.WalletTransactions
                .Where(t => t.UserId == userId)
                .ToList();
        }
    }
}
