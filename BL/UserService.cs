using final_project.models;
using final_project.models.DTOs;
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

        public async Task<User> RegisterUserAsync(RegisterDTO dto, string hashedPassword)
        {
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
                HashPassword = hashedPassword,
                Role = RoleEnum.user,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email && u.HashPassword == hashedPassword);
        }
    }
}
