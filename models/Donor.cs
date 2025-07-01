namespace final_project.models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public required string Name { get; set; }
        public List<Gift> Donation { get; set; } = new List<Gift>();
        public DateTime CreatedAt { get; set; }


    }
}
