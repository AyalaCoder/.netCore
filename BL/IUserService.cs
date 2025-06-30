using final_project.models;
using final_project.models.DTOs;

namespace final_project.BL
{
    public interface IUserService
    {
        Task<User> RegisterUserAsync(RegisterDTO dto, string hashedPassword);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string hashedPassword);
    }
}
