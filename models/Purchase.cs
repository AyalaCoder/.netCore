namespace final_project.models.DTOs
{
    public class Purchase
    {
        public int Id { get; set; }
        public int GiftId { get; set; }
        public Gift Gift { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        
    }
}
