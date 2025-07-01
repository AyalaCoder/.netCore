using final_project.models.DTOs;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace final_project.models
{
    public enum RoleEnum
    {
        user, admin
    }
    public class User
    {
        public int Id { get; set; }
        public string HashPassword { get; set; } = string.Empty;
        public required string Address { get; set; } = string.Empty;
        public RoleEnum Role { get; set; } = RoleEnum.user;
        public string Name { get; set; }
        public required string Email { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


    }
}
