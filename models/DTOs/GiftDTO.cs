namespace final_project.models.DTOs
{
    public class GiftDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string Description { get; set; }
        public required int Price {  get; set; }
        public required int CategoryID {  get; set; }
        
    }
}
