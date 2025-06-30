using final_project.models;
using final_project.models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace final_project.BL
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> RegisterAsync(RegisterDTO dto)
        {
            var user = new User { Email = dto.Email, Name = dto.Name };
            var hasher = new PasswordHasher<User>();
            var hash = hasher.HashPassword(user, dto.Password);

            var newUser = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
                HashPassword = hash,
                Role = RoleEnum.user,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.HashPassword == hashedPassword);
        }
        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
