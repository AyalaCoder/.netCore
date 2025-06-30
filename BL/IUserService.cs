using final_project.models;
using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IUserService
    {
        Task<User> RegisterAsync(RegisterDTO dto);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword);
        Task<User?> GetUserByEmailAsync(string email);
    }
}
