using final_project.models.DTOs;
using Microsoft.AspNetCore.Identity;

namespace final_project.models
{
    public enum RoleEnum
    {
        user, admin
    }
    public class User
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string HashPassword { get; set; }
        public required string Address { get; set; }
        public required RoleEnum Role { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
