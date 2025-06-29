namespace final_project.models
{
    public class Cart
    {
        public int Id { get; set; }
        public required int UserID { get; set; }
        public List<Gift> Gifts { get; set; }=new List<Gift>();
    }
}
