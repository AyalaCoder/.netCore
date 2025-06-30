using System.ComponentModel.DataAnnotations;

namespace final_project.models.DTOs
{
    public class RegisterDTO {
    [Required]
    public string Name { get; set; }

    [Required, EmailAddress]
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }
    
    }
}
