using Microsoft.AspNetCore.Identity;
using OracleJwtApiFull.DTOs;
using OracleJwtApiFull.Models;
using OracleJwtApiFull.Repositories.Interfaces;
using OracleJwtApiFull.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OracleJwtApiFull.Services
{
    public class UserService(IUserRepository userRepository, IJwtService jwtService) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IJwtService _jwtService = jwtService;
        private readonly PasswordHasher<User> _hasher = new PasswordHasher<User>();

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            if (await _userRepository.EmailExistsAsync(dto.Email))
                return "Email already exists.";

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Role = dto.Role,
                PhoneNumber = dto.PhoneNumber,
                CreatedAt = DateTime.UtcNow
            };

            user.Password = _hasher.HashPassword(user, dto.Password);

            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return "Registered successfully.";
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetUserByEmailAsync(dto.Email);
            if (user == null)
                return "Invalid credentials.";

            var result = _hasher.VerifyHashedPassword(user, user.Password, dto.Password);
            if (result == PasswordVerificationResult.Failed)
                return "Invalid credentials.";

            user.LastLogin = DateTime.UtcNow;
            await _userRepository.SaveChangesAsync();

            return _jwtService.GenerateToken(user);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetUserByIdAsync(id);
        }

        public async Task<string> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
                return "User not found.";

            user.Name = dto.Name ?? user.Name;
            user.Email = dto.Email ?? user.Email;
            user.PhoneNumber = dto.PhoneNumber ?? user.PhoneNumber;
            user.Gender = dto.Gender ?? user.Gender;
            user.DateOfBirth = dto.Dob != default ? dto.Dob : user.DateOfBirth;
            user.Role = dto.Role ?? user.Role;

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();

            return "User updated successfully.";
        }
    }
}
