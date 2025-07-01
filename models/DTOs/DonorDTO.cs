namespace final_project.models.DTOs
{
    public class DonorDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public required string Name {  get; set; }
        

    }
}
