namespace final_project.models
{
    public class Donor
    {
     public int Id { get; set; }
        public required string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public required List<Gift> Donation { get; set; } = new List<Gift>();


    }
}
