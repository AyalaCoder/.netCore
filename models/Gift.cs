using final_project.models.DTOs;

namespace final_project.models
{
    public class Gift
    {
    public int Id { get; set; }
    public required string Name { get; set; }
    public string Description { get; set; }
    public required int CategoryID {  get; set; }
    public Category Category { get; set; }
    public int? DonorID {  get; set; }
    public required int Price {  get; set; }
    public ICollection<Purchase>? Purchases { get; set; }
    public int? WinnerID {  get; set; }
    public DateTime UpdatedAt {  get; set; }

    }
}
